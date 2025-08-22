import { useEffect, useState } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";
import { useNavigate } from "react-router-dom";

const Selector = () => {
  const [segments, setSegments] = useState([]);
  const [manufacturers, setManufacturers] = useState([]);
  const [models, setModels] = useState([]);
  const [selectedModel, setSelectedModel] = useState("");
  const navigate = useNavigate();
  const [minQty, setMinQty] = useState(1);
  const [quantity, setQuantity] = useState(1);
  const [selectedSegment, setSelectedSegment] = useState("");
  const [selectedManufacturer, setSelectedManufacturer] = useState("");

  // Fetch segments from backend
  useEffect(() => {
    const token = sessionStorage.getItem("token");
    axios
      .get("http://localhost:8081/segments",{
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        const data = Array.isArray(res.data) ? res.data : res.data.segments;
        setSegments(data);
        console.log("Fetched Segments:", data);
      })
      .catch((err) => console.error("Failed to fetch segments:", err));
  }, []);

  //  On segment select, fetch related manufacturers
  const handleSegmentSelect = (segmentId: string) => {
    setSelectedSegment(segmentId);
    setManufacturers([]);
    setModels([]);
  const token = sessionStorage.getItem("token");
    axios
      .get(`http://localhost:8081/api/sgmfg/get/${segmentId}`,{
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        const data = Array.isArray(res.data) ? res.data : [res.data];
        // Extract manufacturer list from nested mfg_id objects
        const formattedManufacturers = data.map((item: any) => ({
          mfg_id: item.mfg_id,
          mfg_name: item.mfg_name,
        }));
        console.log("data:",data);
        // Optional: Remove duplicates based on mfg_id
        const uniqueManufacturers = formattedManufacturers.filter(
          (value, index, self) =>
            index === self.findIndex((v) => v.mfg_id === value.mfg_id)
        );
        setManufacturers(uniqueManufacturers);
        console.log("Fetched Manufacturers:", uniqueManufacturers);
      })
      .catch((err) => console.error("Failed to fetch manufacturers:", err));
  };

  //  On manufacturer select, fetch models
  const handleManufacturerSelect = (manufacturerId: string) => {
    setSelectedManufacturer(manufacturerId);
    setModels([]);
    const token = sessionStorage.getItem("token");
    axios
      .get(
        `http://localhost:8081/models/segment/${selectedSegment}/manufacturer/${manufacturerId}`
      ,{
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        setModels(res.data);
        console.log("Fetched Models:", res.data);
      })
      .catch((err) => console.error("Failed to fetch models:", err));
  };

  console.log(segments);
  return (
    <div className="min-h-screen bg-gray-900 text-white p-8">
      <h1 className="text-4xl font-bold mb-8 text-center">Vehicle Selection</h1>

      {/* Segment Dropdown */}
      <div className="mb-6">
        <label className="block mb-2 text-lg">Select Segment:</label>
        <select
          value={selectedSegment}
          onChange={(e) => handleSegmentSelect(e.target.value)}
          className="w-full p-3 bg-gray-800 rounded border border-white/20"
        >
          <option value="">-- Select Segment --</option>
          {segments.map((seg: any) => (
            <option key={seg.seg_id} value={seg.seg_id}>
              {seg.seg_name}
            </option>
          ))}
        </select>
      </div>

      {/* Manufacturer Dropdown */}
      {manufacturers.length > 0 && (
        <div className="mb-6">
          <label className="block mb-2 text-lg">Select Manufacturer:</label>
          <select
            value={selectedManufacturer}
            onChange={(e) => handleManufacturerSelect(e.target.value)}
            className="w-full p-3 bg-gray-800 rounded border border-white/20"
          >
            <option value="">-- Select Manufacturer --</option>
            {manufacturers.map((manu: any) => (
              <option key={manu.mfg_id} value={manu.mfg_id}>
                {manu.mfg_name}
              </option>
            ))}
          </select>
        </div>
      )}

      {/* Model Dropdown */}
      {models.length > 0 && (
        <div className="mb-6">
          <label className="block mb-2 text-lg">Select Model:</label>
          <select
            value={selectedModel}
            onChange={(e) => {
              const selected = models.find(
                (mod: any) => mod.model_id === parseInt(e.target.value)
              );
              setSelectedModel(e.target.value);
              setMinQty(selected?.min_qty || 1); // update min qty based on selection
              setQuantity(selected?.min_qty || 1); // default quantity to min_qty
            }}
            className="w-full p-3 bg-gray-800 rounded border border-white/20"
          >
            <option value="">-- Select Model --</option>
            {models.map((mod: any) => (
              <option key={mod.model_id} value={mod.model_id}>
                {mod.model_name}
              </option>
            ))}
          </select>

          {selectedModel && (
            <div className="mt-4">
              <label className="block mb-2 text-lg">
                Quantity (Min: {minQty}):
              </label>
              <input
                type="number"
                min={minQty}
                value={quantity}
                onChange={(e) => {
                  const value = parseInt(e.target.value);
                  if (value >= minQty) setQuantity(value);
                }}
                className="w-full p-3 bg-gray-800 rounded border border-white/20"
              />
            </div>
          )}
        </div>
      )}

      <button
        type="button"
        className="btn btn-outline-light"
        disabled={!selectedModel} // disable if no model selected
        onClick={() =>
          navigate(`/modelview/${selectedModel}`, { state: { quantity } })
        }
      >
        Explore
      </button>
    </div>
  );
};

export default Selector;
