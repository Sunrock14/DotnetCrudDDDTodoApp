import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import UserList from '../pages/UserList';
import TaskList from '../pages/TaskList';
import UserTasks from '../pages/UserTasks';
import TaskDetail from '../pages/TaskDetail';

function App() {
  return (
    <Router>
      <div className="container mt-4">
        <Routes>
          <Route path="/" element={<UserList />} />
          <Route path="/tasks" element={<TaskList />} />
          <Route path="/users/:userId/tasks" element={<UserTasks />} />
          <Route path="/tasks/:taskId" element={<TaskDetail />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
