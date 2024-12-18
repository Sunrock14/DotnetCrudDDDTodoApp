import axios from 'axios';

const API_BASE_URL = 'https://jsonplaceholder.typicode.com';

export const getUsers = () => axios.get(`${API_BASE_URL}/users`);
export const getTasks = () => axios.get(`${API_BASE_URL}/todos`);
export const getTasksByUser = (userId) => axios.get(`${API_BASE_URL}/todos?userId=${userId}`);
export const getTaskDetail = (taskId) => axios.get(`${API_BASE_URL}/todos/${taskId}`);
