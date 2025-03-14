import { API_CONFIG } from "./config";


const handleResponse = async (response) => {
  let data = await response.json(); // Читаем данные один раз

  if(data.items)
  {
    data = data.items;
  }

  if (!response.ok) {
    throw new Error(data.message || `HTTP error! status: ${response.status}`);
  }

  return data;
};

export const api = {
  async fetchData(tableName, params = {}) {
    const endpoint = tableName;

    const url = new URL(`${API_CONFIG.baseUrl}/${endpoint}`);
    
    // Добавляем параметры только для конкретных таблиц
    if (tableName === "userCharacters") {
      const defaultParams = {
        Page: 1,
        PageSize: 10,
        ...params // Позволяет переопределять параметры
      };
      
      Object.entries(defaultParams).forEach(([key, value]) => {
        url.searchParams.append(key, value);
      });
    
    }
    
    const response = await fetch(url.toString());

    return handleResponse(response);

  },

  async createRecord(tableName, data) {
    const endpoint = tableName
    const response = await fetch(
      `${API_CONFIG.baseUrl}/${endpoint}`,
      {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
      }
    );
    return handleResponse(response);
  },

  async updateRecord(tableName, data) {
    const endpoint = tableName
    const response = await fetch(
      `${API_CONFIG.baseUrl}/${endpoint}/${data.id}`,
      {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
      }
    );
    return handleResponse(response);
  },

  async deleteRecord(tableName, id) {
    const endpoint = tableName;
    const response = await fetch(
      `${API_CONFIG.baseUrl}/${endpoint}/${id}`,
      { method: "DELETE" }
    );
    return handleResponse(response);
  },

  async updateCharacterMainInfo(tableName, data) {
    const endpoint = tableName;
    const response = await fetch(
      `${API_CONFIG.baseUrl}/${endpoint}/main-info/${data.id}`,
      {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
      }
    );
    return handleResponse(response);
  },

  async switchUser(data) {
    const endpoint = "userCharacters";
    const response = await fetch(
      `${API_CONFIG.baseUrl}/${endpoint}/switch-user/${data.id}`,
      {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ userId: data.UserId })
      }
    );

    console.log(response)
    return handleResponse(response);
  }
};