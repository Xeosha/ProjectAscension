import React, { useState, useEffect } from "react";
import { api } from "../api/api";
import "./Characters.css"; 

function Characters() {
  const [characters, setCharacters] = useState([]);
  const [selectedCharacter, setSelectedCharacter] = useState(null);
  const [isCreating, setIsCreating] = useState(false);
  const [newCharacter, setNewCharacter] = useState({});

  // Разделенные колонки для разных операций
  const columns = {
    create: [
      { key: "name", label: "Name", type: "text" },
      { key: "biography", label: "Biography", type: "text" },
      { key: "age", label: "Age", type: "number" },
      { key: "rarity", label: "Rarity", type: "number" },
      { key: "minLevel", label: "MinLevel", type: "number" },
      { key: "maxLevel", label: "MaxLevel", type: "number" }
    ],
    update: [
      { key: "name", label: "Name", type: "text" },
      { key: "biography", label: "Biography", type: "text" },
      { key: "age", label: "Age", type: "number" }
    ]
  };

  useEffect(() => {
    fetchCharacters();
  }, []);

  const fetchCharacters = async () => {
    try {
      const data = await api.fetchData("characters");
      setCharacters(data);
    } catch (error) {
      console.error("Error fetching characters:", error);
    }
  };

  const handleEdit = (character) => {
    setSelectedCharacter({...character});
  };

  const handleDelete = async (id) => {
    try {
      await api.deleteRecord("characters", id);
      fetchCharacters();
    } catch (error) {
      console.error("Error deleting character:", error);
    }
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    try {
      // Создаем объект только с разрешенными для обновления полями
      const updateData = {
        id: selectedCharacter.id,
        name: selectedCharacter.name,
        biography: selectedCharacter.biography,
        age: selectedCharacter.age
      };
      
      await api.updateCharacterMainInfo("characters", updateData);
      setSelectedCharacter(null);
      fetchCharacters();
    } catch (error) {
      console.error("Error updating character:", error);
    }
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      // Валидация обязательных полей
      if (!newCharacter.name || !newCharacter.rarity) {
        alert("Name and Rarity are required fields!");
        return;
      }

      await api.createRecord("characters", newCharacter);
      setIsCreating(false);
      setNewCharacter({});
      fetchCharacters();
    } catch (error) {
      console.error("Error creating character:", error);
    }
  };

  const handleChange = (e, field) => {
    const column = [...columns.create, ...columns.update].find(c => c.key === field);
    const value = column?.type === "number" 
      ? parseFloat(e.target.value) || 0 
      : e.target.value;

    if (selectedCharacter) {
      setSelectedCharacter(prev => ({
        ...prev,
        [field]: value
      }));
    } else {
      setNewCharacter(prev => ({
        ...prev,
        [field]: value
      }));
    }
  };

  return (
    <div className="container">
      <div className="header">
        <h1>Characters Management</h1>
        <button 
          className="btn primary"
          onClick={() => setIsCreating(true)}
        >
          + New Character
        </button>
      </div>

      <div className="table-container">
        <table className="data-table">
          <thead>
            <tr>
              {columns.create.map((col) => (
                <th key={col.key}>{col.label}</th>
              ))}
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {characters.map((character) => (
              <tr key={character.id}>
                {columns.create.map((col) => (
                  <td key={col.key}>{character[col.key]}</td>
                ))}
                <td className="actions-cell">
                  <button 
                    className="btn icon-btn edit-btn"
                    onClick={() => handleEdit(character)}
                  >
                    ✏️ Edit
                  </button>
                  <button 
                    className="btn icon-btn delete-btn"
                    onClick={() => handleDelete(character.id)}
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
      {selectedCharacter && (
        <div className="modal-backdrop">
          <div className="modal">
            <div className="modal-header">
              <h2>Edit Character</h2>
              <button 
                className="close-btn"
                onClick={() => setSelectedCharacter(null)}
              >
                &times;
              </button>
            </div>
            <form onSubmit={handleUpdate} className="form">
              <div className="form-grid">
                {columns.update.map((col) => (
                  <div className="input-group" key={col.key}>
                    <label>{col.label}</label>
                    <input
                      type={col.type}
                      value={selectedCharacter[col.key] || ""}
                      onChange={(e) => handleChange(e, col.key)}
                      className="form-input"
                    />
                  </div>
                ))}
              </div>
              <div className="modal-footer">
                <button type="button" className="btn secondary" onClick={() => setSelectedCharacter(null)}>
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
          <div className="modal">
            <div className="modal-header">
              <h2>Create New Character</h2>
              <button 
                className="close-btn"
                onClick={() => setIsCreating(false)}
              >
                &times;
              </button>
            </div>
            <form onSubmit={handleCreate} className="form">
              <div className="form-grid">
                {columns.create.map((col) => (
                  <div className="input-group" key={col.key}>
                    <label>{col.label}</label>
                    <input
                      type={col.type}
                      value={newCharacter[col.key] || ""}
                      onChange={(e) => handleChange(e, col.key)}
                      className="form-input"
                      required={col.key === "name" || col.key === "rarity"}
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
    </div>
  );
}

export default Characters;