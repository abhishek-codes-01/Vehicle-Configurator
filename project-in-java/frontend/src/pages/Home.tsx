import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
// Remove this line:
// import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { Car, Settings, FileText, Shield } from "lucide-react";
import heroImage from "@/assets/hero-automotive.jpg";
import { useNavigate } from "react-router-dom";

export const Home = () => {
  const navigate = useNavigate();

  // Remove these handlers since Header is now managed at App level
  // const handleSignIn = () => {
  //   navigate("/login");
  // };

  // const handleRegistration = () => {
  //   navigate("/register");
  // };

  // const handleContact = () => {
  //   navigate("/contact");
  // };

  // const handleAboutUs = () => {
  //   navigate("/about");
  // };

  return (
    <div className="min-h-screen flex flex-col">
      {/* Remove this Header component */}
      {/* <Header
        onSignIn={handleSignIn}
        onAboutUs={handleAboutUs}
        onContact={handleContact}
        onRegistration={handleRegistration}
      /> */}

      {/* Hero Section */}
      <section className="relative h-[600px] flex items-center justify-center overflow-hidden">
        <div
          className="absolute inset-0 bg-cover bg-center bg-no-repeat"
          style={{ backgroundImage: `url(${heroImage})` }}
        >
          <div className="absolute inset-0 bg-automotive-dark/60" />
        </div>

        <div className="relative z-10 text-center text-white px-4">
          <h1 className="text-5xl md:text-7xl font-bold mb-6">
            Configure Your
            <span className="text-transparent bg-gradient-accent bg-clip-text">
              {" "}
              Dream Vehicle
            </span>
          </h1>
          <p className="text-xl md:text-2xl mb-8 text-white/90 max-w-2xl mx-auto">
            Professional vehicle configuration system for automotive dealers and
            customers
          </p>
          <div className="flex flex-col sm:flex-row gap-4 justify-center">
            <Button
              variant="automotive"
              size="lg"
              onClick={() => navigate("/selector")}
              className="text-lg px-8 py-6 transition-all duration-300 border border-transparent hover:border-white/50"
            >
              Start Configuring
            </Button>

            <Button
              variant="destructive"
              size="lg"
              onClick={() => navigate("/register")}
              className="text-lg px-8 py-6"
            >
              Register Company
            </Button>
          </div>
        </div>
      </section>

      {/* Features Section */}
      <section className="py-20 bg-automotive-light">
        <div className="container mx-auto px-4">
          <div className="text-center mb-16">
            <h2 className="text-4xl font-bold text-foreground mb-4">
              Complete Vehicle Configuration Solution
            </h2>
            <p className="text-xl text-muted-foreground max-w-3xl mx-auto">
              Our comprehensive system provides everything you need for
              professional vehicle configuration, from selection to invoice
              generation.
            </p>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
            <Card className="shadow-card hover:shadow-automotive transition-all duration-300 hover:-translate-y-2">
              <CardContent className="p-8 text-center">
                <div className="w-16 h-16 bg-gradient-primary rounded-lg flex items-center justify-center mx-auto mb-6">
                  <Car className="w-8 h-8 text-primary-foreground" />
                </div>
                <h3 className="text-xl font-semibold mb-4">
                  Vehicle Selection
                </h3>
                <p className="text-muted-foreground">
                  Choose from multiple segments, manufacturers, and models with
                  detailed specifications.
                </p>
              </CardContent>
            </Card>

            <Card className="shadow-card hover:shadow-automotive transition-all duration-300 hover:-translate-y-2">
              <CardContent className="p-8 text-center">
                <div className="w-16 h-16 bg-gradient-accent rounded-lg flex items-center justify-center mx-auto mb-6">
                  <Settings className="w-8 h-8 text-accent-foreground" />
                </div>
                <h3 className="text-xl font-semibold mb-4">
                  Custom Configuration
                </h3>
                <p className="text-muted-foreground">
                  Configure interior, exterior, and standard features with
                  real-time pricing updates.
                </p>
              </CardContent>
            </Card>

            <Card className="shadow-card hover:shadow-automotive transition-all duration-300 hover:-translate-y-2">
              <CardContent className="p-8 text-center">
                <div className="w-16 h-16 bg-gradient-metallic rounded-lg flex items-center justify-center mx-auto mb-6">
                  <FileText className="w-8 h-8 text-automotive-dark" />
                </div>
                <h3 className="text-xl font-semibold mb-4">
                  Invoice Generation
                </h3>
                <p className="text-muted-foreground">
                  Generate professional invoices with detailed pricing and tax
                  calculations.
                </p>
              </CardContent>
            </Card>

            <Card className="shadow-card hover:shadow-automotive transition-all duration-300 hover:-translate-y-2">
              <CardContent className="p-8 text-center">
                <div className="w-16 h-16 bg-automotive-gold rounded-lg flex items-center justify-center mx-auto mb-6">
                  <Shield className="w-8 h-8 text-white" />
                </div>
                <h3 className="text-xl font-semibold mb-4">Secure Platform</h3>
                <p className="text-muted-foreground">
                  Enterprise-grade security with user authentication and data
                  protection.
                </p>
              </CardContent>
            </Card>
          </div>
        </div>
      </section>

      {/* CTA Section */}
      <section className="py-24 bg-gradient-to-br from-[#0f172a] via-[#1e293b] to-[#334155] text-white">
        <div className="container mx-auto px-6 text-center">
          <h2 className="text-5xl font-extrabold mb-6 tracking-tight">
            Ready to Get Started?
          </h2>
          <p className="text-xl mb-10 text-white/80 max-w-2xl mx-auto">
            Join automotive dealers worldwide who trust our vehicle
            configuration platform.
          </p>
          <div className="flex flex-col sm:flex-row gap-4 justify-center">
            <Button
              size="lg"
              onClick={() => navigate("/register")}
              className="text-lg px-8 py-6 bg-white text-black hover:bg-gray-200 transition"
            >
              Register Your Company
            </Button>
            <Button
              size="lg"
              onClick={() => navigate("/contact")}
              className="text-lg px-8 py-6 bg-white text-black hover:bg-gray-200 transition"
            >
              Contact Sales
            </Button>
          </div>
        </div>
      </section>

      <Footer />
    </div>
  );
};

export default Home;
