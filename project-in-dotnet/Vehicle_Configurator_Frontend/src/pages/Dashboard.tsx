import React from 'react';
import { useAuth } from '../context/AuthProvider';

const Dashboard: React.FC = () => {
  const { user, logout } = useAuth();

  return (
    <div className="max-w-4xl mx-auto mt-10 p-6 bg-white rounded-lg shadow-md">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-3xl font-bold">Dashboard</h1>
        <button
          onClick={logout}
          className="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
        >
          Logout
        </button>
      </div>

      <div className="bg-blue-50 p-4 rounded-lg">
        <h2 className="text-xl font-semibold mb-2">Welcome, {user?.username}!</h2>
        <p className="text-gray-600">You have successfully logged in to your dashboard.</p>
      </div>

      <div className="mt-6 grid grid-cols-1 md:grid-cols-3 gap-4">
        <div className="bg-green-100 p-4 rounded-lg">
          <h3 className="font-semibold text-green-800">Protected Content</h3>
          <p className="text-green-600">This content is only visible to authenticated users.</p>
        </div>
        <div className="bg-yellow-100 p-4 rounded-lg">
          <h3 className="font-semibold text-yellow-800">User Info</h3>
          <p className="text-yellow-600">Username: {user?.username}</p>
        </div>
        <div className="bg-purple-100 p-4 rounded-lg">
          <h3 className="font-semibold text-purple-800">Session Status</h3>
          <p className="text-purple-600">Active and secured with JWT</p>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
