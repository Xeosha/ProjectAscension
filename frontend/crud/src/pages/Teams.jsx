import React, { useState, useEffect } from "react";
import { api } from "../api/api";
import "./Teams.css"; 

function Teams() {
  const [teams, setTeams] = useState([]);
  const [users, setUsers] = useState([]);
  const [userCharacters, setUserCharacters] = useState([]);
  const [isCreating, setIsCreating] = useState(false);
  const [isEditing, setIsEditing] = useState(false);
  const [expandedTeamId, setExpandedTeamId] = useState(null);
  const [selectedTeam, setSelectedTeam] = useState(null);
  const [newTeam, setNewTeam] = useState({
    name: "",
    userId: "",
    characterIds: []
  });

  const teamColumns = [
    { key: "name", label: "Name" },
    { key: "power", label: "Power" },
    { 
      key: "user", 
      label: "User Created", 
      format: (user) => user?.userName || "Unknown"
    }
  ];

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const [teamsData, usersData, userCharactersData] = await Promise.all([
        api.fetchData("teams"),
        api.fetchData("users"),
        api.fetchData("userCharacters")
      ]);
      
      setTeams(teamsData);
      setUsers(usersData);
      setUserCharacters(userCharactersData);
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };

  const TeamDetails = ({ team }) => (
    <div className="team-details">
      <div className="details-section">
        <h4>Owner:</h4>
        <p>{team.user?.userName}</p>
      </div>

      <div className="details-section">
        <h4>Members ({team.members.length}):</h4>
        <div className="members-grid">
          {team.members.map(member => (
            <div key={member.id} className="member-card">
              <h5>{member.name}</h5>
            </div>
          ))}
        </div>
      </div>
    </div>
  );

  const TableRow = ({ team }) => {
    const isExpanded = expandedTeamId === team.id;

    return (
      <>
        <tr key={team.id}>
          {teamColumns.map(col => (
            <td key={col.key}>
              {col.format 
                ? col.format(team[col.key])
                : team[col.key]}
            </td>
          ))}
          <td>
            <button onClick={() => handleEdit(team)}>Edit</button>
            <button onClick={() => handleDelete(team.id)}>Delete</button>
            <button 
              onClick={() => setExpandedTeamId(isExpanded ? null : team.id)}
              className="details-btn"
            >
              {isExpanded ? "▲ Hide" : "▼ Details"}
            </button>
          </td>
        </tr>
        {isExpanded && (
          <tr className="details-row">
            <td colSpan={teamColumns.length + 1}>
              <TeamDetails team={team} />
            </td>
          </tr>
        )}
      </>
    );
  };

  const getAvailableCharacters = (userId) => {
    console.log(userId)
    if (!userId) return [];
    return userCharacters.filter(uc => 
      uc.user?.id === userId && 
      uc.team === null
    );
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    if (!newTeam.name || !newTeam.userId) {
      alert("Name and User are required!");
      return;
    }
    
    try {
      await api.createRecord("teams", {
        ...newTeam,
        characterIds: newTeam.characterIds
      });
      
      setIsCreating(false);
      setNewTeam({ name: "", userId: "", characterIds: [] });
      fetchData();
    } catch (error) {
      console.error("Error creating team:", error);
    }
  };

  const handleCharacterSelect = (ucId, isChecked) => {
    setNewTeam(prev => ({
      ...prev,
      characterIds: isChecked 
        ? [...prev.characterIds, ucId]
        : prev.characterIds.filter(id => id !== ucId)
    }));
  };

  const handleEdit = (team) => {
    setSelectedTeam({
      id: team.id,
      name: team.name,
      user: team.user,
      addCharacters: [],
      deleteCharacters: [],
      currentMembers: team.members.map(m => m.id)
    });
    setIsEditing(true);
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    if (!selectedTeam.name) return;
    
    console.log(selectedTeam);

    try {
      await api.updateRecord("teams", {
        id: selectedTeam.id,
        name: selectedTeam.name,
        addCharacters: selectedTeam.addCharacters,
        deleteCharacters: selectedTeam.deleteCharacters
      });
      
      setIsEditing(false);
      setSelectedTeam(null);
      fetchData();
    } catch (error) {
      console.error("Update error:", error);
    }
  };

  const handleDelete = async (id) => {
    if (window.confirm("Delete this team?")) {
      try {
        await api.deleteRecord("teams", id);
        fetchData();
      } catch (error) {
        console.error("Error deleting team:", error);
        alert("Cannot delete team with members!");
      }
    }
  };

  const handleCharacterToggle = (ucId, isChecked, isCurrentMember) => {
    const field = isCurrentMember ? 'deleteCharacters' : 'addCharacters';
    setSelectedTeam(prev => ({
      ...prev,
      [field]: isChecked 
        ? [...prev[field], ucId]
        : prev[field].filter(id => id !== ucId)
    }));
  };

  return (
    <div className="container">
      <div className="header">
        <h1 className="title">Teams Management</h1>
        <button 
          className="btn primary"
          onClick={() => setIsCreating(true)}
        >
          <span className="icon">+</span> Create Team
        </button>
      </div>

      {/* Create Modal */}
      {isCreating && (
        <div className="modal-backdrop">
          <div className="modal">
            <div className="modal-header">
              <h2>Create New Team</h2>
              <button 
                className="close-btn"
                onClick={() => setIsCreating(false)}
              >
                &times;
              </button>
            </div>
            
            <form onSubmit={handleCreate} className="form">
              <div className="input-group">
                <label>Team Name</label>
                <input
                  type="text"
                  value={newTeam.name}
                  onChange={(e) => setNewTeam(prev => ({...prev, name: e.target.value}))}
                  className="text-input"
                  placeholder="Enter team name"
                  required
                />
              </div>

              <div className="input-group">
                <label>Owner</label>
                <select
                  value={newTeam.userId}
                  onChange={(e) => setNewTeam(prev => ({
                    ...prev, 
                    userId: e.target.value,
                    characterIds: []
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

              {newTeam.userId && (
                <div className="input-group">
                  <label>Available Characters</label>
                  <div className="characters-grid">
                    {getAvailableCharacters(newTeam.userId).map(uc => (
                      <label 
                        key={uc.id} 
                        className={`character-card ${
                          newTeam.characterIds.includes(uc.id) ? 'selected' : ''
                        }`}
                      >
                        <input
                          type="checkbox"
                          checked={newTeam.characterIds.includes(uc.id)}
                          onChange={(e) => handleCharacterSelect(uc.id, e.target.checked)}
                          className="checkbox"
                        />
                        <div className="character-info">
                          <span className="character-name">
                            {uc.character?.name || "Unnamed Character"}
                          </span>
                          <div className="character-stats">
                            <span className="stat">
                              <span className="stat-icon">⚔️</span>
                              {uc.attack}
                            </span>
                            <span className="stat">
                              <span className="stat-icon">❤️</span>
                              {uc.health}
                            </span>
                          </div>
                        </div>
                      </label>
                    ))}
                  </div>
                </div>
              )}

              <div className="modal-footer">
                <button type="button" className="btn secondary" onClick={() => setIsCreating(false)}>
                  Cancel
                </button>
                <button type="submit" className="btn primary">
                  Create Team
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* Teams Table */}
      <div className="table-container">
        <table className="data-table">
          <thead>
            <tr>
              {teamColumns.map(col => (
                <th key={col.key}>{col.label}</th>
              ))}
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {teams.map(team => (
              <TableRow key={team.id} team={team} />
            ))}
          </tbody>
        </table>
      </div>

      {/* Edit Modal */}
      {isEditing && selectedTeam && (
        <div className="modal-backdrop">
          <div className="modal">
            <div className="modal-header">
              <h2>Edit Team</h2>
              <button 
                className="close-btn"
                onClick={() => setIsEditing(false)}
              >
                &times;
              </button>
            </div>
            
            <form onSubmit={handleUpdate} className="form">
              <div className="input-group">
                <label>Team Name</label>
                <input
                  type="text"
                  value={selectedTeam.name}
                  onChange={(e) => setSelectedTeam(prev => ({
                    ...prev,
                    name: e.target.value
                  }))}
                  className="text-input"
                  required
                />
              </div>

              <div className="members-section">
                <h3 className="section-title">
                  Current Members ({selectedTeam.currentMembers.length})
                  <span className="section-subtitle">Select to remove</span>
                </h3>
                <div className="members-grid">
                  {userCharacters
                    .filter(uc => selectedTeam.currentMembers.includes(uc.id))
                    .map(uc => (
                      <label 
                        key={uc.id} 
                        className={`member-card ${
                          selectedTeam.deleteCharacters.includes(uc.id) ? 'selected-remove' : ''
                        }`}
                      >
                        <input
                          type="checkbox"
                          checked={selectedTeam.deleteCharacters.includes(uc.id)}
                          onChange={(e) => handleCharacterToggle(
                            uc.id,
                            e.target.checked,
                            true
                          )}
                          className="checkbox"
                        />
                        <div className="character-info">
                          <span className="character-name">
                            {uc.character?.name}
                          </span>
                        </div>
                      </label>
                    ))}
                </div>
              </div>

              <div className="available-section">
                <h3 className="section-title">
                  Available Characters
                  <span className="section-subtitle">Select to add</span>
                </h3>
                <div className="characters-grid">
                  {getAvailableCharacters(selectedTeam.user.userId)
                    .map(uc => (
                      <label 
                        key={uc.id} 
                        className={`character-card ${
                          selectedTeam.addCharacters.includes(uc.id) ? 'selected-add' : ''
                        }`}
                      >
                        <input
                          type="checkbox"
                          checked={selectedTeam.addCharacters.includes(uc.id)}
                          onChange={(e) => handleCharacterToggle(
                            uc.id,
                            e.target.checked,
                            false
                          )}
                          className="checkbox"
                        />
                        <div className="character-info">
                          <span className="character-name">
                            {uc.character?.name}
                          </span>
                          <div className="character-stats">
                            <span className="stat">
                              <span className="stat-icon">⚔️</span>
                              {uc.attack}
                            </span>
                            <span className="stat">
                              <span className="stat-icon">❤️</span>
                              {uc.health}
                            </span>
                          </div>
                        </div>
                      </label>
                    ))}
                </div>
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
    </div>
  );
}

export default Teams;