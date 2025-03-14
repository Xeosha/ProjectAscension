import api from './config';

export const professionAPI = {
  getAll: () => api.get('proffesions'),
  create: (data) => api.post('proffesions', data),
  update: (id, data) => api.put(`proffesions/${id}`, data),
  delete: (id) => api.delete(`proffesions/${id}`),
};