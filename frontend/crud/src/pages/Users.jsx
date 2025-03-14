import React, { useState, useEffect } from "react";
import { api } from "../api/api";

function Users() {
  const [users, setUsers] = useState([]);
  const [teams, setTeams] = useState([]);
  const [characters, setCharacters] = useState([]);
  const [selectedUser, setSelectedUser] = useState(null);
  const [expandedUserId, setExpandedUserId] = useState(null);
  const [isEditing, setIsEditing] = useState(false);
  const [isCreating, setIsCreating] = useState(false);
  const [newUser, setNewUser] = useState({
    name: "",
    email: "",
    userName: ""
  });

  const userColumns = [
    { key: "name", label: "Name", type: "text" },
    { key: "email", label: "Email", type: "email" },
    { key: "userName", label: "Username", type: "text" }
  ];

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const [usersData, teamsData, charactersData] = await Promise.all([
        api.fetchData("users"),
        api.fetchData("teams"),
        api.fetchData("userCharacters")
      ]);
      console.log(charactersData);
      setUsers(usersData);
      setTeams(teamsData);
      setCharacters(charactersData);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  const UserDetails = ({ userId }) => {
    const userTeams = teams.filter(team => team.user?.userId === userId);
    const userCharacters = characters.filter(char => char.user.id === userId);

    return (
      <div className="user-details">
        <div className="details-section">
          <h4>Teams ({userTeams.length}):</h4>
          {userTeams.length > 0 ? (
            <div className="teams-list">
              {userTeams.map(team => (
                <div key={team.id} className="team-card">
                  <h5>{team.name}</h5>
                  <p>Power: {team.power}</p>
                </div>
              ))}
            </div>
          ) : <p>No teams found</p>}
        </div>

        <div className="details-section">
          <h4>Characters ({userCharacters.length}):</h4>
          {userCharacters.length > 0 ? (
            <div className="characters-grid">
              {userCharacters.map(character => (
                <div key={character.id} className="character-card">
                  <h5>{character.user.name}</h5>
                  <p>Attack: {character.health}</p>
                  <p>Health: {character.attack}</p>
                </div>
              ))}
            </div>
          ) : <p>No characters found</p>}
        </div>
      </div>
    );
  };

  const TableRow = ({ user }) => {
    const isExpanded = expandedUserId === user.id;

    return (
      <>
        <tr key={user.id}>
          {userColumns.map((col) => (
            <td key={col.key}>{user[col.key]}</td>
          ))}
          <td>
            <button onClick={() => handleEdit(user)}>Edit</button>
            <button onClick={() => handleDelete(user.id)}>Delete</button>
            <button 
              onClick={() => setExpandedUserId(isExpanded ? null : user.id)}
              className="details-btn"
            >
              {isExpanded ? "▲ Hide" : "▼ Details"}
            </button>
          </td>
        </tr>
        {isExpanded && (
          <tr className="details-row">
            <td colSpan={userColumns.length + 1}>
              <UserDetails userId={user.id} />
            </td>
          </tr>
        )}
      </>
    );
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      if (!newUser.name || !newUser.email) {
        alert("Name and Email are required!");
        return;
      }
      
      await api.createRecord("users", newUser);
      setIsCreating(false);
      setNewUser({ name: "", email: "", userName: "" });
      fetchData();
    } catch (error) {
      console.error("Error creating user:", error);
    }
  };

  const handleCreateChange = (e, field) => {
    setNewUser(prev => ({
      ...prev,
      [field]: e.target.value
    }));
  };

  const handleEdit = (user) => {
    setSelectedUser(user);
    setIsEditing(true);
  };

  const handleDelete = async (id) => {
    if (window.confirm("Are you sure you want to delete this user?")) {
      try {
        await api.deleteRecord("users", id);
        fetchData();
      } catch (error) {
        console.error("Error deleting user:", error);
        alert("Cannot delete user with existing dependencies!");
      }
    }
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    try {
      await api.updateRecord("users", selectedUser);
      setIsEditing(false);
      setSelectedUser(null);
      fetchData();
    } catch (error) {
      console.error("Error updating user:", error);
    }
  };

  const handleChange = (e, field) => {
    setSelectedUser(prev => ({
      ...prev,
      [field]: e.target.value
    }));
  };

  return (
    <div className="container">
      <div className="flex justify-between items-center mb-20">
        <h1 className="text-2xl font-bold">Users Management</h1>
        <button 
          className="btn btn-primary"
          onClick={() => setIsCreating(true)}
        >
          + New User
        </button>
      </div>

      {/* Table */}
      <table className="data-table">
        <thead>
          <tr>
            {userColumns.map((col) => (
              <th key={col.key}>{col.label}</th>
            ))}
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user) => (
            <TableRow key={user.id} user={user} />
          ))}
        </tbody>
      </table>

      {/* Create Modal */}
      {isCreating && (
        <div className="modal-overlay">
          <div className="modal-content">
            <div className="modal-header">
              <h2 className="modal-title">Create New User</h2>
            </div>
            <form onSubmit={handleCreate}>
              {userColumns.map((col) => (
                <div className="form-group" key={col.key}>
                  <label className="form-label">{col.label}</label>
                  <input
                    className="form-input"
                    type={col.type}
                    value={newUser[col.key] || ""}
                    onChange={(e) => handleCreateChange(e, col.key)}
                    required={col.key === "name" || col.key === "email"}
                  />
                </div>
              ))}
              <div className="flex gap-10 mt-20">
                <button type="submit" className="btn btn-primary">Create</button>
                <button 
                  type="button" 
                  className="btn btn-secondary"
                  onClick={() => setIsCreating(false)}
                >
                  Cancel
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* Edit Modal */}
      {isEditing && selectedUser && (
        <div className="modal-overlay">
          <div className="modal-content">
            <div className="modal-header">
              <h2 className="modal-title">Edit User</h2>
            </div>
            <form onSubmit={handleUpdate}>
              {userColumns.map((col) => (
                <div className="form-group" key={col.key}>
                  <label className="form-label">{col.label}</label>
                  <input
                    className="form-input"
                    type={col.type}
                    value={selectedUser[col.key] || ""}
                    onChange={(e) => handleChange(e, col.key)}
                  />
                </div>
              ))}
              <div className="flex gap-10 mt-20">
                <button type="submit" className="btn btn-primary">Save</button>
                <button 
                  type="button" 
                  className="btn btn-secondary"
                  onClick={() => setIsEditing(false)}
                >
                  Cancel
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}

export default Users;