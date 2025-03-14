import React, { useState, useEffect } from "react";
import { api } from "../api/api";
import "./Professions.css"; 

function Professions() {
  const [professions, setProfessions] = useState([]);
  const [selectedProfession, setSelectedProfession] = useState(null);
  const [isCreating, setIsCreating] = useState(false);
  const [newProfession, setNewProfession] = useState({ name: "" });

  useEffect(() => {
    fetchProfessions();
  }, []);

  const fetchProfessions = async () => {
    try {
      const data = await api.fetchData("proffesions");
      setProfessions(data);
    } catch (error) {
      console.error("Error fetching professions:", error);
    }
  };

  const handleEdit = (profession) => {
    setSelectedProfession({ ...profession });
  };

  const handleDelete = async (id) => {
    try {
      await api.deleteRecord("proffesions", id);
      fetchProfessions();
    } catch (error) {
      console.error("Error deleting profession:", error);
    }
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    try {
      await api.updateRecord("proffesions", selectedProfession);
      setSelectedProfession(null);
      fetchProfessions();
    } catch (error) {
      console.error("Error updating profession:", error);
    }
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      if (!newProfession.name.trim()) {
        alert("Name is required!");
        return;
      }
      
      await api.createRecord("proffesions", newProfession);
      setIsCreating(false);
      setNewProfession({ name: "" });
      fetchProfessions();
    } catch (error) {
      console.error("Error creating profession:", error);
    }
  };

  const handleChange = (e) => {
    const value = e.target.value;
    
    if (selectedProfession) {
      setSelectedProfession(prev => ({ ...prev, name: value }));
    } else {
      setNewProfession(prev => ({ ...prev, name: value }));
    }
  };

  return (
    <div className="container">
      <div className="header">
        <h1>Professions Management</h1>
        <button 
          className="btn primary"
          onClick={() => setIsCreating(true)}
        >
          + New Profession
        </button>
      </div>

      <div className="table-container">
        <table className="data-table">
          <thead>
            <tr>
              <th>Name</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {professions.map((profession) => (
              <tr key={profession.id}>
                <td>{profession.name}</td>
                <td className="actions-cell">
                  <button 
                    className="btn icon-btn edit-btn"
                    onClick={() => handleEdit(profession)}
                  >
                    ✏️ Edit
                  </button>
                  <button 
                    className="btn icon-btn delete-btn"
                    onClick={() => handleDelete(profession.id)}
                  >
                    🗑️ Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Edit Modal */}
      {selectedProfession && (
        <div className="modal-backdrop">
          <div className="modal small-modal">
            <div className="modal-header">
              <h2>Edit Profession</h2>
              <button 
                className="close-btn"
                onClick={() => setSelectedProfession(null)}
              >
                &times;
              </button>
            </div>
            <form onSubmit={handleUpdate} className="form">
              <div className="input-group">
                <label>Name</label>
                <input
                  type="text"
                  value={selectedProfession.name}
                  onChange={handleChange}
                  className="text-input"
                  required
                />
              </div>
              <div className="modal-footer">
                <button type="button" className="btn secondary" onClick={() => setSelectedProfession(null)}>
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

      {/* Create Modal */}
      {isCreating && (
        <div className="modal-backdrop">
          <div className="modal small-modal">
            <div className="modal-header">
              <h2>Create New Profession</h2>
              <button 
                className="close-btn"
                onClick={() => setIsCreating(false)}
              >
                &times;
              </button>
            </div>
            <form onSubmit={handleCreate} className="form">
              <div className="input-group">
                <label>Name</label>
                <input
                  type="text"
                  value={newProfession.name}
                  onChange={handleChange}
                  className="text-input"
                  required
                />
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
    </div>
  );
}

export default Professions;