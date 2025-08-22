// import api from './axiosConfig';

// const invoiceService = {
//   emailInvoice: async (invoiceData) => {
//     try {
//       console.log('📧 Sending invoice email request...');
//       console.log('📋 Invoice data:', invoiceData);

//       const response = await api.post('/api/invoice/email', invoiceData);
//       console.log('✅ Invoice email response:', response.data);

//       return response.data;
//     } catch (error) {
//       console.error('❌ Invoice service error:', error);

//       // Create a more user-friendly error message
//       let errorMessage = 'Failed to send invoice email';

//       if (error.response) {
//         // Server responded with error status
//         console.error('Server Error Details:', error.response.data);

//         if (error.response.data?.message) {
//           errorMessage = error.response.data.message;
//         } else if (error.response.data?.error) {
//           errorMessage = error.response.data.error;
//         } else if (error.response.status === 403) {
//           errorMessage = 'Access denied. Please log in again.';
//         } else if (error.response.status === 401) {
//           errorMessage = 'Authentication required. Please log in.';
//         } else {
//           errorMessage = `Server error: ${error.response.status}`;
//         }
//       } else if (error.request) {
//         // Network error
//         errorMessage = 'Network error: Unable to reach server';
//       } else {
//         // Request setup error
//         errorMessage = error.message || 'Unknown error occurred';
//       }

//       throw new Error(errorMessage);
//     }
//   }
// };

// export default invoiceService;
