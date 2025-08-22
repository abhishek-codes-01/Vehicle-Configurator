import axios from "axios";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

const initialFormData = {
  username: "",
  password: "",
  role: "",
  holding: "",
  st_no: "",
  tel: "",
  addr: "",
  auth_name: "",
  cell: "",
  city: "",
  company_name: "",
  desig: "",
  email: "",
  pin: "",
  reg_no: "",
  state: "",
};

const RegistrationForm = () => {
  const [formData, setFormData] = useState(initialFormData);
  const navigate = useNavigate();

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const isFormValid = () => {
    for (let key in formData) {
      if (!formData[key as keyof typeof formData]?.toString().trim()) {
        alert(`Please fill in the ${key.replace(/_/g, " ")} field.`);
        return false;
      }
    }

    // Optional: Validate email format
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(formData.email)) {
      alert("Invalid email format.");
      return false;
    }

    return true;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (!isFormValid()) return;

    const preparedData = {
      ...formData,
      st_no: parseInt(formData.st_no),
      tel: parseFloat(formData.tel),
      cell: parseFloat(formData.cell),
      pin: parseInt(formData.pin),
      reg_no: parseFloat(formData.reg_no),
    };

    try {
      const response = await axios.post(
        "https://localhost:7027/api/auth/register",
        preparedData,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      alert("User registered successfully");
      setFormData(initialFormData);
    } catch (error: any) {
      if (error.response?.status === 409) {
        alert("Username already exists");
      } else {
        alert("Registration failed");
        console.error(error);
      }
    }
  };

  return (
    <form
      onSubmit={handleSubmit}
      className="max-w-2xl mx-auto p-6 bg-white rounded-lg shadow-md space-y-4"
    >
      <h2 className="text-xl font-bold mb-4">Registration Form</h2>

      <div className="grid grid-cols-2 gap-4">
        <input
          name="username"
          type="text"
          placeholder="Username"
          required
          onChange={handleChange}
        />
        <input
          name="password"
          type="password"
          placeholder="Password"
          required
          onChange={handleChange}
        />
        <input
          name="role"
          type="text"
          placeholder="Role"
          required
          onChange={handleChange}
        />
        <select
          name="holding"
          required
          onChange={handleChange}
          value={formData.holding}
          className="border rounded p-2"
        >
          <option value="">-- Select Holding Type --</option>
          <option value="Proprietary">Proprietary</option>
          <option value="Pvt. Ltd">Pvt. Ltd</option>
          <option value="Ltd">Ltd</option>
        </select>
        <input
          name="st_no"
          type="number"
          placeholder="Street No."
          required
          onChange={handleChange}
        />
        <input
          name="tel"
          type="tel"
          placeholder="Telephone"
          required
          onChange={handleChange}
        />
        <input
          name="addr"
          type="text"
          placeholder="Address"
          required
          onChange={handleChange}
        />
        <input
          name="auth_name"
          type="text"
          placeholder="Authorised Name"
          required
          onChange={handleChange}
        />
        <input
          name="cell"
          type="tel"
          placeholder="Mobile"
          required
          onChange={handleChange}
        />
        <input
          name="city"
          type="text"
          placeholder="City"
          required
          onChange={handleChange}
        />
        <input
          name="company_name"
          type="text"
          placeholder="Company Name"
          required
          onChange={handleChange}
        />
        <input
          name="desig"
          type="text"
          placeholder="Designation"
          required
          onChange={handleChange}
        />
        <input
          name="email"
          type="email"
          placeholder="Email"
          required
          onChange={handleChange}
        />
        <input
          name="pin"
          type="number"
          placeholder="PIN Code"
          required
          onChange={handleChange}
        />
        <input
          name="reg_no"
          type="text"
          placeholder="Registration No."
          required
          onChange={handleChange}
        />
        <input
          name="state"
          type="text"
          placeholder="State"
          required
          onChange={handleChange}
        />
      </div>

      <button
        type="submit"
        className="mt-4 bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
      >
        Register
      </button>
    </form>
  );
};

export default RegistrationForm;
