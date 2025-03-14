import React, { useState, useEffect } from "react";
import { api } from "../api/api";
import "./UserCharacters.css"; // Создайте этот файл стилей

function UserCharacters() {
  const [userCharacters, setUserCharacters] = useState([]);
  const [users, setUsers] = useState([]);
  const [professions, setProfessions] = useState([]);
  const [characters, setCharacters] = useState([]);
  const [teams, setTeams] = useState([]);
  const [selectedUserChar, setSelectedUserChar] = useState(null);
  const [isEditing, setIsEditing] = useState(false);
  const [isCreating, setIsCreating] = useState(false);
  const [isSwitchingUser, setIsSwitchingUser] = useState(false);
  const [newUserChar, setNewUserChar] = useState({
    attack: 0,
    defense: 0,
    health: 0,
    userId: "",
    characterId: ""
  });

  const columns = [
    { key: "attack", label: "Attack", editable: true, type: "number" },
    { key: "defense", label: "Defense", editable: true, type: "number" },
    { key: "health", label: "Health", editable: true, type: "number" },
    { key: "user", label: "User", editable: false },
    { key: "character", label: "Character", editable: false },
    { key: "proffesion", label: "Profession", editable: true, type: "select" },
    { key: "team", label: "Team", editable: false }
  ];

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const [ucData, usersData, professionsData, charsData, teamsData] = 
        await Promise.all([
          api.fetchData("userCharacters"),
          api.fetchData("users"),
          api.fetchData("proffesions"),
          api.fetchData("characters"),
          api.fetchData("teams")
        ]);

      
      setUserCharacters(ucData);
      setUsers(usersData);
      setProfessions(professionsData);
      setCharacters(charsData);
      setTeams(teamsData);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      if (!newUserChar.userId || !newUserChar.characterId) {
        alert("User and Character are required!");
        return;
      }
      
      await api.createRecord("userCharacters", {
        UserId: newUserChar.userId,
        CharacterId: newUserChar.characterId,
        Attack: newUserChar.attack,
        Defense: newUserChar.defense,
        Health: newUserChar.health
      });
      
      setIsCreating(false);
      setNewUserChar({ attack: 0, defense: 0, health: 0, userId: "", characterId: "" });
      fetchData();
    } catch (error) {
      console.error("Error creating user character:", error);
    }
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    try {
      await api.updateCharacterMainInfo("userCharacters", {
        id: selectedUserChar.id,
        ProffesionId: selectedUserChar.proffesion?.id || null,
        Attack: selectedUserChar.attack,
        Defense: selectedUserChar.defense,
        Health: selectedUserChar.health
      });
      
      setIsEditing(false);
      setSelectedUserChar(null);
      fetchData();
    } catch (error) {
      console.error("Error updating user character:", error);
    }
  };

  const handleSwitchUser = async (userId) => {
    try {
      console.log(selectedUserChar.id)
      console.log(userId)

      await api.switchUser({
        id: selectedUserChar.id,
        UserId: userId
      });

      
      
      setIsSwitchingUser(false);
      setSelectedUserChar(null);
      fetchData();
    } catch (error) {
      console.error("Error switching user:", error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await api.deleteRecord("userCharacters", id);
      fetchData();
    } catch (error) {
      console.error("Error deleting user character:", error);
    }
  };

  const renderCellValue = (item, column) => {
    const value = item[column.key];
    
    if (typeof value === "object") {
      return value?.name || "None";
    }
    
    if (column.key === "proffesion" && !value) {
      return "None";
    }
    
    return value;
  };

  return (
    <div className="user-characters-container">
      <div className="uc-header">
        <h1>User Characters Management</h1>
        <button 
          className="btn primary"
          onClick={() => setIsCreating(true)}
        >
          + New User Character
        </button>
      </div>

      {/* Create Modal */}
      {isCreating && (
        <div className="modal-backdrop">
          <div className="modal">
            <div className="modal-header">
              <h2>Create New User Character</h2>
              <button 
                className="close-btn"
                onClick={() => setIsCreating(false)}
              >
                &times;
              </button>
            </div>
            
            <form onSubmit={handleCreate} className="form">
              <div className="form-row">
                <div className="input-group">
                  <label>User</label>
                  <select
                    value={newUserChar.userId}
                    onChange={(e) => setNewUserChar(prev => ({
                      ...prev,
                      userId: e.target.value
                    }))}
                    className="select-input"
                    required
                  >
                    <option value="">Select User</option>
                    {users.map(user => (
                      <option key={user.id} value={user.id}>
                        {user.userName}
                      </option>
                    ))}
                  </select>
                </div>

                <div className="input-group">
                  <label>Character</label>
                  <select
                    value={newUserChar.characterId}
                    onChange={(e) => setNewUserChar(prev => ({
                      ...prev,
                      characterId: e.target.value
                    }))}
                    className="select-input"
                    required
                  >
                    <option value="">Select Character</option>
                    {characters.map(char => (
                      <option key={char.id} value={char.id}>
                        {char.name}
                      </option>
                    ))}
                  </select>
                </div>
              </div>

              <div className="form-row stats-row">
                {["attack", "defense", "health"].map(field => (
                  <div className="input-group stat-input" key={field}>
                    <label>{field.charAt(0).toUpperCase() + field.slice(1)}</label>
                    <input
                      type="number"
                      value={newUserChar[field]}
                      onChange={(e) => setNewUserChar(prev => ({
                        ...prev,
                        [field]: parseInt(e.target.value) || 0
                      }))}
                      className="number-input"
                      min="0"
                      required
                    />
                  </div>
                ))}
              </div>

              <div className="modal-footer">
                <button type="button" className="btn secondary" onClick={() => setIsCreating(false)}>
                  Cancel
                </button>
                <button type="submit" className="btn primary">
                  Create
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* Main Table */}
      <div className="table-wrapper">
        <table className="data-table">
          <thead>
            <tr>
              {columns.map(col => (
                <th key={col.key}>{col.label}</th>
              ))}
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {userCharacters.map(uc => (
              <tr key={uc.id}>
                {columns.map(col => (
                  <td key={col.key} className={col.editable ? 'editable-cell' : ''}>
                    {renderCellValue(uc, col)}
                  </td>
                ))}
                <td className="actions-cell">
                  <div className="actions-group">
                    <button 
                      className="btn icon-btn edit-btn"
                      onClick={() => {
                        setSelectedUserChar(uc);
                        setIsEditing(true);
                      }}
                    >
                      ✏️ Edit
                    </button>
                    <button 
                      className="btn icon-btn switch-btn"
                      onClick={() => {
                        setSelectedUserChar(uc);
                        setIsSwitchingUser(true);
                      }}
                    >
                      🔄 Switch
                    </button>
                    <button 
                      className="btn icon-btn delete-btn"
                      onClick={() => handleDelete(uc.id)}
                    >
                      🗑️ Delete
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Edit Modal */}
      {isEditing && selectedUserChar && (
        <div className="modal-backdrop">
          <div className="modal">
            <div className="modal-header">
              <h2>Edit User Character</h2>
              <button 
                className="close-btn"
                onClick={() => setIsEditing(false)}
              >
                &times;
              </button>
            </div>
            
            <form onSubmit={handleUpdate} className="form">
              <div className="form-row">
                {columns.filter(col => col.editable).map(col => (
                  <div className="input-group" key={col.key}>
                    <label>{col.label}</label>
                    {col.type === "select" ? (
                      <select
                        value={selectedUserChar.proffesion?.id || ""}
                        onChange={(e) => setSelectedUserChar(prev => ({
                          ...prev,
                          proffesion: professions.find(p => p.id === e.target.value) || null
                        }))}
                        className="select-input"
                      >
                        <option value="">None</option>
                        {professions.map(p => (
                          <option key={p.id} value={p.id}>
                            {p.name}
                          </option>
                        ))}
                      </select>
                    ) : (
                      <input
                        type={col.type}
                        value={selectedUserChar[col.key]}
                        onChange={(e) => setSelectedUserChar(prev => ({
                          ...prev,
                          [col.key]: col.type === "number" 
                            ? parseInt(e.target.value) || 0 
                            : e.target.value
                        }))}
                        className="number-input"
                        min={col.type === "number" ? 0 : undefined}
                      />
                    )}
                  </div>
                ))}
              </div>

              <div className="modal-footer">
                <button type="button" className="btn secondary" onClick={() => setIsEditing(false)}>
                  Cancel
                </button>
                <button type="submit" className="btn primary">
                  Save Changes
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* Switch User Modal */}
      {isSwitchingUser && selectedUserChar && (
        <div className="modal-backdrop">
          <div className="modal small-modal">
            <div className="modal-header">
              <h2>Switch User</h2>
              <button 
                className="close-btn"
                onClick={() => setIsSwitchingUser(false)}
              >
                &times;
              </button>
            </div>
            
            <div className="form">
              <div className="input-group">
                <label>Select New User</label>
                <select
                  onChange={(e) => handleSwitchUser(e.target.value)}
                  className="select-input"
                >
                  <option value="">Select User</option>
                  {users.map(user => (
                    <option key={user.id} value={user.id}>
                      {user.userName}
                    </option>
                  ))}
                </select>
              </div>

              <div className="modal-footer">
                <button 
                  type="button" 
                  className="btn secondary"
                  onClick={() => setIsSwitchingUser(false)}
                >
                  Cancel
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default UserCharacters;