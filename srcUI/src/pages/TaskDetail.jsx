import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getTaskDetail } from '../services/api';

function TaskDetail() {
  const { taskId } = useParams();
  const [task, setTask] = useState(null);

  useEffect(() => {
    getTaskDetail(taskId).then((response) => setTask(response.data));
  }, [taskId]);

  if (!task) {
    return <div>Yükleniyor...</div>;
  }

  return (
    <div>
      <h2>Görev Detayı</h2>
      <p><strong>Başlık:</strong> {task.title}</p>
      <p><strong>Durum:</strong> {task.completed ? 'Tamamlandı' : 'Tamamlanmadı'}</p>
    </div>
  );
}

export default TaskDetail;
