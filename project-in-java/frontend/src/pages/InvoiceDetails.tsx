import React, { useState } from "react";
import { useAuth } from "../context/AuthProvider";
import invoiceService from "../service/invoiceService";

interface InvoiceDetailsProps {
  modelDetails: {
    model_id: string;
    model_name: string;
    price: number;
    img_path?: string;
    manufacturer?: { mfg_name: string };
    segment?: { seg_name: string };
  };
  selectedConfigurableOptions: Record<
    string,
    {
      alt_id: string;
      comp_id: number | string;
      comp_name: string;
      comp_type: string;
      price_impact: number;
    }
  >;
  vehicleDetails: {
    config_id: string;
    comp_id: number | string;
    comp_name: string;
    comp_type: string;
    isConfig: string;
  }[];
  allComponents: Record<string, string>;
  calculatedTotalPrice: number;
  quantity: number;
  taxAmount: number;
  invoiceMessage: string | null;
  setCurrentView: (view: "details" | "configure" | "invoice") => void;
}

const InvoiceDetails: React.FC<InvoiceDetailsProps> = ({
  modelDetails,
  selectedConfigurableOptions,
  vehicleDetails,
  allComponents,
  calculatedTotalPrice,
  quantity,
  taxAmount,
  invoiceMessage,
  setCurrentView,
}) => {
  const [isEmailSending, setIsEmailSending] = useState(false);
  const [emailMessage, setEmailMessage] = useState<string | null>(null);
  const { user, isAuthenticated } = useAuth();

  const handleEmailInvoice = async () => {
    try {
      setIsEmailSending(true);
      setEmailMessage(null);

      console.log('🔍 Auth check - User:', user);
      console.log('🔍 Auth check - isAuthenticated:', isAuthenticated());
      console.log('🔍 Auth check - Token:', sessionStorage.getItem('token') ? 'exists' : 'missing');

      if (!isAuthenticated() || !user) {
        setEmailMessage("Please log in to send invoice email");
        return;
      }

      // Prepare components data for email
      const components = Object.values(selectedConfigurableOptions).map(opt => ({
        type: opt.comp_type,
        name: opt.comp_name,
        selection: opt.alt_id.startsWith("default") ? "Default" : "Alternate",
        priceImpact: opt.price_impact
      }));

      const invoiceData = {
        invoiceId: invoiceMessage?.split("Invoice ID: ")[1] || "INV-" + Date.now(),
        modelName: modelDetails.model_name,
        manufacturerName: modelDetails.manufacturer?.mfg_name || "Unknown",
        segmentName: modelDetails.segment?.seg_name || "Unknown",
        basePrice: modelDetails.price,
        unitPrice: calculatedTotalPrice,
        taxAmount: taxAmount,
        quantity: quantity,
        totalAmount: (calculatedTotalPrice + taxAmount) * quantity,
        components: components
      };

      console.log('📧 Sending invoice email...');
      const response = await invoiceService.emailInvoice(invoiceData);
      setEmailMessage(response.message || "Invoice sent successfully!");
    } catch (error: any) {
      console.error('❌ Email invoice error:', error);
      setEmailMessage(error.message || "Failed to send invoice email");
    } finally {
      setIsEmailSending(false);
    }
  };

  // Add debug button (remove in production)
  const handleDebug = () => {
    console.log('=== 🐛 DEBUG INFO ===');
    console.log('Token:', sessionStorage.getItem('token'));
    console.log('User from context:', user);
    console.log('User from storage:', sessionStorage.getItem('user'));
    console.log('Is authenticated:', isAuthenticated());
    console.log('==================');
  };

  return (
    <div className="p-8 bg-gray-50 rounded-xl shadow-inner">
      <div className="max-w-4xl mx-auto bg-white p-8 rounded-lg shadow-lg">
        {/* Email Message */}
        {emailMessage && (
          <div className={`mb-4 p-4 rounded ${
            emailMessage.includes("successfully") || emailMessage.includes("sent")
              ? "bg-green-100 text-green-800 border border-green-300"
              : "bg-red-100 text-red-800 border border-red-300"
          }`}>
            {emailMessage}
          </div>
        )}

        {/* Header */}
        <div className="border-b-2 border-gray-300 pb-6 mb-6">
          <h1 className="text-4xl font-bold text-gray-900 mb-2">INVOICE</h1>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            <div>
              <p className="text-gray-600 mb-1">
                <strong>Date:</strong> {new Date().toLocaleDateString()}
              </p>
              <p className="text-gray-600 mb-1">
                <strong>Customer:</strong> {user?.username || "Online Customer"}
              </p>
            </div>
            <div className="text-right">
              {invoiceMessage?.includes("Invoice ID:") && (
                <p className="text-gray-600 mb-1">
                  <strong>Invoice ID:</strong>{" "}
                  {invoiceMessage.split("Invoice ID: ")[1]}
                </p>
              )}
            </div>
          </div>
        </div>

        {/* Vehicle Details */}
        <div className="mb-8">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4 border-b border-gray-200 pb-2">
            Vehicle Details
          </h2>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            <div className="space-y-2">
              <p className="text-lg">
                <strong>Model:</strong> {modelDetails.model_name}
              </p>
              <p className="text-gray-700">
                <strong>Manufacturer:</strong>{" "}
                {modelDetails.manufacturer?.mfg_name}
              </p>
              <p className="text-gray-700">
                <strong>Segment:</strong> {modelDetails.segment?.seg_name}
              </p>
              <p className="text-gray-700">
                <strong>Base Price:</strong> $
                {modelDetails.price.toLocaleString()}
              </p>
              <p className="text-gray-700">
                <strong>Quantity:</strong> {quantity}
              </p>
            </div>
            {modelDetails.img_path && (
              <img
                src={"http://localhost:8081" + modelDetails.img_path}
                alt={modelDetails.model_name}
                className="w-48 h-32 object-cover rounded-lg shadow-md"
                onError={(e) => {
                  e.currentTarget.src =
                    "https://placehold.co/300x200/cccccc/333333?text=No+Image";
                }}
              />
            )}
          </div>
        </div>

        {/* Selected Components */}
        <div className="mb-8">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4 border-b border-gray-200 pb-2">
            Selected Components
          </h2>
          {Object.values(selectedConfigurableOptions).length ? (
            <div className="overflow-x-auto">
              <table className="w-full border-collapse border border-gray-300">
                <thead>
                  <tr className="bg-gray-100">
                    <th className="border px-4 py-3 text-left font-semibold">
                      Type
                    </th>
                    <th className="border px-4 py-3 text-left font-semibold">
                      Name
                    </th>
                    <th className="border px-4 py-3 text-left font-semibold">
                      Selection
                    </th>
                    <th className="border px-4 py-3 text-right font-semibold">
                      Impact
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {Object.values(selectedConfigurableOptions).map((opt, i) => (
                    <tr
                      key={opt.alt_id}
                      className={i % 2 === 0 ? "bg-white" : "bg-gray-50"}
                    >
                      <td className="border px-4 py-3">{opt.comp_type}</td>
                      <td className="border px-4 py-3">{opt.comp_name}</td>
                      <td className="border px-4 py-3">
                        <span
                          className={`inline-block px-2 py-1 rounded-full text-xs font-medium ${
                            opt.alt_id.startsWith("default")
                              ? "bg-blue-100 text-blue-800"
                              : "bg-green-100 text-green-800"
                          }`}
                        >
                          {opt.alt_id.startsWith("default")
                            ? "Default"
                            : "Alternate"}
                        </span>
                      </td>
                      <td className="border px-4 py-3 text-right">
                        <span
                          className={
                            opt.price_impact >= 0
                              ? "text-green-600 font-semibold"
                              : "text-red-600 font-semibold"
                          }
                        >
                          {opt.price_impact >= 0 ? "+" : ""}$
                          {Math.abs(opt.price_impact).toLocaleString()}
                        </span>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          ) : (
            <p className="text-center text-gray-500">
              No components configured; using defaults.
            </p>
          )}
        </div>

        {/* Price Breakdown */}
        <div className="bg-gray-50 p-6 rounded-lg mb-8">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4">
            Price Breakdown
          </h2>
          <div className="space-y-3">
            <div className="flex justify-between">
              <span>Unit Price:</span>
              <span>${calculatedTotalPrice.toLocaleString()}</span>
            </div>
            <div className="flex justify-between">
              <span>Tax (18%):</span>
              <span>${taxAmount.toLocaleString()}</span>
            </div>
            <div className="flex justify-between font-semibold">
              <span>Price + Tax:</span>
              <span>${(calculatedTotalPrice + taxAmount).toLocaleString()}</span>
            </div>
            <div className="flex justify-between">
              <span>Quantity:</span>
              <span>{quantity}</span>
            </div>
            <hr />
            <div className="flex justify-between text-xl font-bold text-blue-600">
              <span>Total:</span>
              <span>
                $
                {((calculatedTotalPrice + taxAmount) * quantity).toLocaleString()}
              </span>
            </div>
          </div>
        </div>

        {/* Actions */}
        <div className="flex justify-center gap-4 flex-wrap">
          <button
            onClick={() => setCurrentView("details")}
            className="bg-gray-600 hover:bg-gray-700 text-white py-2 px-6 rounded"
          >
            Back
          </button>
          <button
            onClick={() => setCurrentView("configure")}
            className="bg-blue-600 hover:bg-blue-700 text-white py-2 px-6 rounded"
          >
            Modify
          </button>
          <button
            onClick={() => window.print()}
            className="bg-green-600 hover:bg-green-700 text-white py-2 px-6 rounded"
          >
            Print
          </button>
          <button
            onClick={handleEmailInvoice}
            disabled={isEmailSending || !isAuthenticated()}
            className={`py-2 px-6 rounded text-white ${
              isEmailSending || !isAuthenticated()
                ? "bg-gray-400 cursor-not-allowed"
                : "bg-purple-600 hover:bg-purple-700"
            }`}
          >
            {isEmailSending ? "Sending..." : "Email Invoice"}
          </button>
         
          
        </div>
      </div>
    </div>
  );
};

export default InvoiceDetails;
