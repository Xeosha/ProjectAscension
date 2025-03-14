import api from './config';

export const characterAPI = {
  getAll: () => api.get('characters'),
  create: (data) => api.post('characters', data),
  update: (id, data) => api.put(`characters/${id}`, data),
  delete: (id) => api.delete(`characters/${id}`),
};