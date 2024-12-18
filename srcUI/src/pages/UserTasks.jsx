import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getTasksByUser } from '../services/api';

function UserTasks() {
  const { userId } = useParams();
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    getTasksByUser(userId).then((response) => setTasks(response.data));
  }, [userId]);

  return (
    <div>
      <h2>Kullanıcı Görevleri</h2>
      <ul className="list-group">
        {tasks.map((task) => (
          <li key={task.id} className="list-group-item">
            {task.title}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default UserTasks;
