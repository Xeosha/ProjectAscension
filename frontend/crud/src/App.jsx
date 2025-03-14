import React, { useEffect, useState } from "react";
import styled from "styled-components";
import { api } from "./api/api";
import Characters from "./pages/Characters";
import Teams from "./pages/Teams";
import Professions from "./pages/Professions";
import Users from "./pages/Users";
import UserCharacters from "./pages/UserCharacters";



const Container = styled.div`
  padding: 2rem;
  max-width: 1200px;
  margin: 0 auto;
`;

const Header = styled.h1`
  color: #2c3e50;
  margin-bottom: 2rem;
  font-size: 2.5rem;
`;

const TableSelector = styled.div`
  margin-bottom: 2rem;
  label {
    font-weight: 500;
    margin-right: 1rem;
    color: #34495e;
  }
  select {
    padding: 0.5rem 1rem;
    border-radius: 6px;
    border: 1px solid #bdc3c7;
    font-size: 1rem;
    transition: all 0.3s ease;
    
    &:hover {
      border-color: #3498db;
    }
    
    &:focus {
      outline: none;
      box-shadow: 0 0 0 3px rgba(52, 152, 219, 0.3);
    }
  }
`;

const Loader = styled.div`
  display: inline-block;
  width: 50px;
  height: 50px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #3498db;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  
  @keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
  }
`;

const ErrorMessage = styled.div`
  padding: 1rem;
  background: #fee;
  border: 1px solid #f5c6cb;
  color: #721c24;
  border-radius: 4px;
  margin: 1rem 0;
`;


const tables = [
    { value: "users", label: "Users" },
    { value: "teams", label: "Teams" },
    { value: "userCharacters", label: "User Characters" },
    { value: "proffessions", label: "Professions" },
    { value: "characters", label: "Characters" }
];

function App() {
    const [tableName, setTableName] = useState("characters");

    const renderTable = () => {
        switch(tableName) {
            case 'characters':
                return <Characters/>;
            case 'users':
                return <Users />;
            case 'teams':
                return <Teams  />;
            case 'userCharacters':
                return <UserCharacters/>;
            case 'proffessions':
                return <Professions/>;
            default:
                return <div>Select a table</div>;
        }
    }

    return (
        <Container>
            <Header>Database Admin Panel</Header>

            <TableSelector>
                <label>Select Table:</label>
                <select
                    value={tableName}
                    onChange={e => setTableName(e.target.value)}
                >
                    {tables.map(t => (
                        <option key={t.value} value={t.value}>
                            {t.label}
                        </option>
                    ))}
                </select>
            </TableSelector>

            {
                renderTable() 
            }

        </Container>
    );
}

export default App;
