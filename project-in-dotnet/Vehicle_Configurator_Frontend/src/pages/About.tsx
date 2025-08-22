import { Link } from "react-router-dom";

const AboutUs = () => {
  return (
    <div className="bg-white py-10 px-4 md:px-20">
      <h2 className="text-3xl font-bold text-center text-gray-800 mb-2">
        About Us
      </h2>
      <p className="text-center text-gray-600 mb-10">
        Discover who we are, what we do, and why we love helping you build the
        vehicle of your dreams.
      </p>

      <div className="flex flex-col md:flex-row items-center justify-center gap-10">
        <img
          src="images/man.png"
          alt="About Us"
          className="rounded-lg shadow-lg w-full md:w-[400px] object-cover"
        />

        <div className="max-w-xl">
          <h3 className="text-lg font-bold text-gray-800 mb-3">
            Welcome to Vehicle Configurator App! 🚗
          </h3>
          <p className="text-gray-700 mb-4">
            We're passionate about helping users build, customize, and visualize
            their dream vehicles — whether you're a car enthusiast, designer, or
            dealer.
          </p>
          <p className="text-gray-700 mb-6">
            Our app offers a seamless, real-time configuration experience using
            modern tech like <b>Next.js</b> and <b>React Bootstrap</b>.
          </p>
          <Link to="/Selector">
            <button className="bg-black text-white px-5 py-2 rounded hover:bg-gray-800 transition">
              Explore Configurator
            </button>
          </Link>
        </div>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mt-16">
        <div className="bg-white p-6 border rounded shadow text-center">
          <h4 className="text-blue-600 font-semibold text-lg mb-2">
            Modern UI
          </h4>
          <p className="text-gray-600 text-sm">
            Clean, responsive, and mobile-friendly interface.
          </p>
        </div>
        <div className="bg-white p-6 border rounded shadow text-center">
          <h4 className="text-green-600 font-semibold text-lg mb-2">
            Fast & Reliable
          </h4>
          <p className="text-gray-600 text-sm">
            Built with performance-first technologies like Next.js 14.
          </p>
        </div>
        <div className="bg-white p-6 border rounded shadow text-center">
          <h4 className="text-red-600 font-semibold text-lg mb-2">
            Customizable
          </h4>
          <p className="text-gray-600 text-sm">
            Easy to extend for dealerships or users with specific needs.
          </p>
        </div>
      </div>
    </div>
  );
};

export default AboutUs;
