import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Car, User, Phone, FileText, LogOut } from "lucide-react";
import { useAuth } from "@/context/AuthProvider";
import { useNavigate } from "react-router-dom";

export interface HeaderProps {
  onSignIn?: () => void;
  onAboutUs?: () => void;
  onContact?: () => void;
  onRegistration?: () => void;
}

export const Header = ({ onAboutUs, onContact }: HeaderProps) => {
  const { user, isAuthenticated, logout } = useAuth();
  const navigate = useNavigate();
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);

  const handleSignIn = () => navigate("/login");
  const handleRegistration = () => navigate("/register");

  const handleLogout = async () => {
    await logout();
    navigate("/");
  };

  const handleAboutUs = () => {
    if (onAboutUs) onAboutUs();
    else navigate("/about");
  };

  const handleContact = () => {
    if (onContact) onContact();
    else navigate("/contact");
  };

  return (
    <header className="w-full bg-background border-b border-border shadow-card">
      <div className="container mx-auto px-4 py-4">
        <div className="flex items-center justify-between">
          {/* Logo */}
          <div
            className="flex items-center gap-3 cursor-pointer"
            onClick={() => navigate("/")}
          >
            <div className="w-10 h-10 bg-gradient-primary rounded-lg flex items-center justify-center">
              <Car className="w-6 h-6 text-primary-foreground" />
            </div>
            <div>
              <h1 className="text-xl font-bold text-foreground">ApexCraft</h1>
              <p className="text-xs text-muted-foreground">
                Vehicle Configurator
              </p>
            </div>
          </div>

          {/* Desktop Navigation */}
          <nav className="hidden md:flex items-center gap-6">
            <Button variant="ghost" onClick={handleAboutUs}>
              About Us
            </Button>
            <Button variant="ghost" onClick={handleContact} className="gap-2">
              <Phone className="w-4 h-4" />
              Contact Us
            </Button>

            {isAuthenticated() && (
              <Button variant="ghost" onClick={() => navigate("/selector")}>
                Vehicle Selector
              </Button>
            )}

            {isAuthenticated() ? (
              <div className="flex items-center gap-4">
                <span className="text-sm text-muted-foreground">
                  Welcome,{" "}
                  <span className="font-medium text-foreground">
                    {user?.username}
                  </span>
                </span>
                <Button
                  variant="destructive"
                  onClick={handleLogout}
                  className="gap-2"
                  size="sm"
                >
                  <LogOut className="w-4 h-4" />
                  Sign Out
                </Button>
              </div>
            ) : (
              <div className="flex items-center gap-3">
                <Button
                  variant="ghost"
                  onClick={handleSignIn}
                  className="gap-2"
                >
                  <User className="w-4 h-4" />
                  Sign In
                </Button>
                <Button
                  variant="automotive"
                  onClick={handleRegistration}
                  className="gap-2"
                >
                  <FileText className="w-4 h-4" />
                  Registration
                </Button>
              </div>
            )}
          </nav>

          {/* Mobile Menu Button */}
          <Button
            variant="ghost"
            className="md:hidden"
            onClick={() => setMobileMenuOpen(!mobileMenuOpen)}
          >
            <svg
              className="w-6 h-6"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                strokeWidth={2}
                d={
                  mobileMenuOpen
                    ? "M6 18L18 6M6 6l12 12" // X icon when open
                    : "M4 6h16M4 12h16M4 18h16" // Hamburger icon when closed
                }
              />
            </svg>
          </Button>
        </div>

        {/* Mobile Menu Items */}
        {mobileMenuOpen && (
          <div className="md:hidden mt-4 flex flex-col gap-3">
            <Button variant="ghost" onClick={handleAboutUs}>
              About Us
            </Button>
            <Button variant="ghost" onClick={handleContact} className="gap-2">
              <Phone className="w-4 h-4" />
              Contact Us
            </Button>

            {isAuthenticated() && (
              <Button variant="ghost" onClick={() => navigate("/selector")}>
                Vehicle Selector
              </Button>
            )}

            {isAuthenticated() ? (
              <>
                <span className="text-sm text-muted-foreground">
                  Welcome,{" "}
                  <span className="font-medium text-foreground">
                    {user?.username}
                  </span>
                </span>
                <Button
                  variant="destructive"
                  onClick={handleLogout}
                  className="gap-2"
                  size="sm"
                >
                  <LogOut className="w-4 h-4" />
                  Sign Out
                </Button>
              </>
            ) : (
              <>
                <Button
                  variant="ghost"
                  onClick={handleSignIn}
                  className="gap-2"
                >
                  <User className="w-4 h-4" />
                  Sign In
                </Button>
                <Button
                  variant="automotive"
                  onClick={handleRegistration}
                  className="gap-2"
                >
                  <FileText className="w-4 h-4" />
                  Registration
                </Button>
              </>
            )}
          </div>
        )}
      </div>
    </header>
  );
};
