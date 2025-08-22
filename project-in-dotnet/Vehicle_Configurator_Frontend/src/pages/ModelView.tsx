import React, { useEffect, useState } from "react";
import { useLocation, useParams } from "react-router-dom";
import axios from "axios";
import InvoiceDetails from "./InvoiceDetails";
import { useAuth } from "../context/AuthProvider";
import { jwtDecode } from "jwt-decode";

type SelectedConfigurableOption = {
  altId: string;
  compId: number | string;
  compName: string;
  compType: string;
  priceImpact: number;
};

interface JwtPayload {
  email: string;
}

// const token = sessionStorage.getItem("token");

// const decoded = jwtDecode<JwtPayload>(token);

const ModelView = () => {
  const { user } = useAuth();
  const { modelId } = useParams<{ modelId: string }>();
  const [modelDetails, setModelDetails] = useState<any>(null);
  const [decoded, setDecoded] = useState<JwtPayload | null>(null);
  const [vehicleDetails, setVehicleDetails] = useState<any[]>([]);
  const [allComponents, setAllComponents] = useState<Record<string, string>>(
    {}
  );
  const [alternateComponents, setAlternateComponents] = useState<any[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [invoiceMessage, setInvoiceMessage] = useState<string | null>(null);

  const [currentView, setCurrentView] = useState<
    "details" | "configure" | "invoice"
  >("details");
  const [selectedCompType, setSelectedCompType] = useState<string | null>(null);
  const [selectedConfigurableOptions, setSelectedConfigurableOptions] =
    useState<Record<string, SelectedConfigurableOption>>({});
  const [calculatedTotalPrice, setCalculatedTotalPrice] = useState(0);

  const [invoiceId, setInvoiceId] = useState<number | null>(null);

  const location = useLocation();
  const quantity = location.state?.quantity || 1;
  const segment = location.state?.selectedSegmentName;
  const manufacturer = location.state?.selectedManufacturerName;

  useEffect(() => {
    const token = sessionStorage.getItem("token");
    if (token) {
      try {
        setDecoded(jwtDecode<JwtPayload>(token));
      } catch (err) {
        console.error("Invalid token:", err);
      }
    }
  }, []);

  useEffect(() => {
    if (!modelId) return;
    setLoading(true);
    setError(null);
    axios
      .get(`https://localhost:7027/api/model/${modelId}`)
      .then((res) => {
        setModelDetails(res.data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Failed to load model details:", err);
        setError("Failed to load model details. Please check the server.");
        setLoading(false);
      });
  }, [modelId]);

  useEffect(() => {
    if (!modelId) return;
    axios
      .get(`https://localhost:7027/api/vehicledetail/by-model/${modelId}`)
      .then((res) => {
        setVehicleDetails(res.data);
      })
      .catch((err) => {
        console.error("Failed to load vehicle details:", err);
        setError("Failed to load vehicle details. Please check the server.");
      });
  }, [modelId]);

  useEffect(() => {
    axios
      .get("https://localhost:7027/api/component")
      .then((res) => {
        const map: Record<string, string> = {};
        res.data.forEach(
          (c: { compId: string; compName: string }) =>
            (map[c.compId] = c.compName)
        );
        setAllComponents(map);
      })
      .catch((err) => {
        console.error("Failed to load all components:", err);
        setError("Failed to load component list. Please check the server.");
      });
  }, []);

  useEffect(() => {
    if (!modelId) return;
    axios
      .get(
        `https://localhost:7027/api/alternatecomponentmaster/by-model/${modelId}`
      )
      .then((res) => {
        setAlternateComponents(res.data);
      })
      .catch((err) => {
        console.error("Failed to load alternate components:", err);
        setError(
          "Failed to load alternate components. Please check the server."
        );
      });
  }, [modelId]);

  useEffect(() => {
    let total = modelDetails?.price || 0;
    Object.values(selectedConfigurableOptions).forEach(
      (o) => (total += o.priceImpact)
    );
    setCalculatedTotalPrice(total);
  }, [modelDetails, selectedConfigurableOptions]);

  const handleGenerateInvoice = async () => {
    if (!modelDetails) {
      setInvoiceMessage("Cannot generate invoice: Model not loaded.");
      return;
    }
    setInvoiceMessage("Generating invoice...");

    const taxAmount = Number((calculatedTotalPrice * 0.18).toFixed(2));
    const invoiceData = {
      modelId: modelDetails.modelId,
      amt: modelDetails.price,
      tax: taxAmount,
      totalAmt: (calculatedTotalPrice + taxAmount) * quantity,
      customerDetail: user?.username || "Online Customer",
      invDate: new Date().toISOString(),
    };
    console.log(invoiceData);

    try {
      const res = await axios.post(
        "https://localhost:7027/api/invoiceheader/save",
        invoiceData
      );
      console.log("Invoice save response:", res.data);

      setInvoiceMessage(
        `Invoice generated successfully! Invoice ID: ${res.data.invId}`
      );
      setInvoiceId(res.data.invId);
      setCurrentView("invoice");
    } catch (err: any) {
      console.error("Failed to generate invoice:", err);
      setInvoiceMessage(
        `Failed to generate invoice: ${err.response?.data || err.message}`
      );
    }
  };

  if (loading)
    return <div className="text-center py-8">Loading model details...</div>;
  if (error)
    return <div className="text-center py-8 text-red-500">{error}</div>;
  if (!modelDetails)
    return <div className="text-center py-8">No model data found.</div>;

  const configurable = vehicleDetails.filter((v) => v.isConfig === "Y");
  const types = Array.from(new Set(configurable.map((v) => v.compType)));

  return (
    <div className="max-w-4xl mx-auto p-6 bg-white rounded-xl shadow-lg my-8 font-sans">
      {/* Navigation Buttons */}
      <div className="flex justify-center gap-4 mb-6">
        {["details", "configure", "invoice"].map((view) => (
          <button
            key={view}
            onClick={() => setCurrentView(view as any)}
            className={`px-6 py-2 rounded-full font-semibold transition ${
              currentView === view
                ? "bg-blue-600 text-white shadow-lg"
                : "bg-gray-200 text-gray-700 hover:bg-gray-300"
            }`}
          >
            {view.charAt(0).toUpperCase() + view.slice(1)}
          </button>
        ))}
      </div>
      <hr className="my-6 border-gray-200" />

      {/* Details View */}
      {currentView === "details" && (
        <>
          <div className="flex flex-col md:flex-row items-center md:items-start mb-6">
            <img
              src={`https://localhost:7027${modelDetails.imgPath}`}
              

              alt={modelDetails.modelName}
              className="w-full md:w-1/3 h-48 md:h-auto object-cover rounded-lg shadow-md mb-4 md:mb-0 md:mr-6"
              onError={(e) => {
                e.currentTarget.src =
                  "https://placehold.co/300x200/cccccc/333333?text=No+Image";
              }}
            />
            <div className="flex-grow">
              <h1 className="text-3xl font-bold mb-2">
                {modelDetails.modelName}
              </h1>
              <p className="mb-1">
                <strong>Segment:</strong> {segment}
              </p>
              <p className="mb-1">
                <strong>Manufacturer:</strong> {manufacturer}
              </p>
              <p className="mb-1">
                <strong>Base Price:</strong> $
                {modelDetails.price.toLocaleString()}
              </p>
              <p className="mb-1">
                <strong>Quantity:</strong> {quantity}
              </p>
              <p className="mt-4 font-semibold">
                <strong>Current Configured Price:</strong> $
                {(calculatedTotalPrice * quantity).toLocaleString()}
              </p>
            </div>
          </div>

          <hr className="my-6 border-gray-200" />

          <div className="mt-6">
            <h2 className="text-2xl font-semibold mb-4">
              Available Vehicle Variants
            </h2>
            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
              {vehicleDetails.map((vehicle) => (
                <div
                  key={vehicle.configId}
                  className="bg-gray-50 p-4 rounded-lg shadow-sm border border-gray-200"
                >
                  <p className="text-sm uppercase font-medium text-gray-500 mb-1">
                    {vehicle.compType}
                  </p>
                  <p className="text-lg font-semibold text-gray-800">
                    {allComponents[vehicle.compId] || vehicle.compName}
                  </p>
                  <span
                    className={`inline-block mt-2 px-2 py-1 text-xs font-semibold rounded-full ${
                      vehicle.isConfig === "Y"
                        ? "bg-green-100 text-green-700"
                        : "bg-red-100 text-red-700"
                    }`}
                  >
                    {vehicle.isConfig === "Y" ? "Configurable" : "Fixed"}
                  </span>
                </div>
              ))}
            </div>

            <button
              onClick={() => setCurrentView("configure")}
              className="mt-6 w-full bg-blue-600 hover:bg-blue-700 text-white font-semibold py-3 rounded-lg"
            >
              Configure Your Vehicle
            </button>
          </div>
        </>
      )}

      {/* Configure View */}
      {currentView === "configure" && (
        <div className="mt-8 p-6 bg-blue-50 rounded-xl shadow-inner">
          <h2 className="text-2xl font-semibold mb-5">
            Select Component Category
          </h2>
          <div className="flex flex-wrap gap-4 mb-8">
            {types.map((type) => (
              <button
                key={type}
                onClick={() =>
                  setSelectedCompType(selectedCompType === type ? null : type)
                }
                className={`px-6 py-3 rounded-lg font-semibold ${
                  selectedCompType === type
                    ? "bg-blue-700 text-white"
                    : "bg-blue-500 text-white hover:bg-blue-600"
                }`}
              >
                {type}
              </button>
            ))}
          </div>

          {configurable
            .filter((v) => !selectedCompType || v.compType === selectedCompType)
            .map((defaultComp) => {
              const relatedAlternates = alternateComponents.filter(
                (alt) => alt.compId === defaultComp.compId
              );

              const defaultAltId = `default-${defaultComp.compId}`;

              return (
                <div
                  key={defaultComp.configId}
                  className="mb-8 p-4 bg-white rounded-lg shadow-md border"
                >
                  <h3 className="text-xl font-semibold mb-2">
                    Default:{" "}
                    {allComponents[defaultComp.compId] || defaultComp.compName}
                  </h3>
                  <p className="mb-4">Type: {defaultComp.compType}</p>

                  <label className="flex items-center mb-3">
                    <input
                      type="radio"
                      name={`comp-${defaultComp.compId}`}
                      checked={
                        selectedConfigurableOptions[defaultComp.compId]
                          ?.altId === defaultAltId
                      }
                      onChange={() => {
                        setSelectedConfigurableOptions((prev) => ({
                          ...prev,
                          [defaultComp.compId]: {
                            altId: defaultAltId,
                            compId: defaultComp.compId,
                            compName:
                              allComponents[defaultComp.compId] ||
                              defaultComp.compName,
                            compType: defaultComp.compType,
                            priceImpact: 0,
                          },
                        }));
                      }}
                    />
                    <span className="ml-2">Use Default Component</span>
                  </label>

                  {relatedAlternates.map((alt) => {
                    const altId = `alt-${alt.altId}`;
                    return (
                      <li key={alt.altId} className="mb-1 flex items-center">
                        <input
                          type="radio"
                          name={`comp-${defaultComp.compId}`}
                          checked={
                            selectedConfigurableOptions[defaultComp.compId]
                              ?.altId === altId
                          }
                          onChange={() => {
                            setSelectedConfigurableOptions((prev) => ({
                              ...prev,
                              [defaultComp.compId]: {
                                altId: altId,
                                compId: alt.altCompId,
                                compName:
                                  allComponents[alt.altCompId] ||
                                  `Component #${alt.altCompId}`,
                                compType: defaultComp.compType,
                                priceImpact: alt.deltaPrice,
                              },
                            }));
                          }}
                        />
                        <span className="ml-2">
                          {allComponents[alt.altCompId] ||
                            `Component #${alt.altCompId}`}
                        </span>
                        <span
                          className={`ml-auto px-2 py-1 text-sm font-medium ${
                            alt.deltaPrice >= 0
                              ? "bg-green-100 text-green-800"
                              : "bg-red-100 text-red-800"
                          }`}
                        >
                          {alt.deltaPrice >= 0 ? "+" : ""}
                          {alt.deltaPrice}
                        </span>
                      </li>
                    );
                  })}
                  {/* Reset Button */}
                  <button
                    onClick={() =>
                      setSelectedConfigurableOptions((prev) => {
                        const updated = { ...prev };
                        delete updated[defaultComp.compId]; // Remove the selection
                        return updated;
                      })
                    }
                    className="mt-3 px-3 py-1 bg-gray-300 hover:bg-gray-400 rounded-md text-sm"
                  >
                    Reset Choice
                  </button>
                </div>
              );
            })}

          <button
            onClick={handleGenerateInvoice}
            className="mt-6 w-full bg-green-600 hover:bg-green-700 text-white font-semibold py-3 rounded-lg"
          >
            Generate Invoice
          </button>
        </div>
      )}

      {/* Invoice View */}
      {currentView === "invoice" && (
        <InvoiceDetails
          modelDetails={modelDetails}
          selectedConfigurableOptions={selectedConfigurableOptions}
          vehicleDetails={vehicleDetails}
          allComponents={allComponents}
          calculatedTotalPrice={calculatedTotalPrice}
          quantity={quantity}
          taxAmount={Number((calculatedTotalPrice * 0.18).toFixed(2))}
          invoiceMessage={invoiceMessage}
          invoiceId={invoiceId}
          setCurrentView={setCurrentView}
          user={user}
          email={decoded.email}
          segmentName={
            location.state?.selectedSegmentName ||
            modelDetails.segment?.segName ||
            ""
          }
          manufacturerName={
            location.state?.selectedManufacturerName ||
            modelDetails.manufacturer?.mfgName ||
            ""
          }
        />
      )}
    </div>
  );
};

export default ModelView;
