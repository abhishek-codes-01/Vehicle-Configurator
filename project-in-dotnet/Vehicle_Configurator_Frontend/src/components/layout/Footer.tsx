export const Footer = () => {
  return (
    <footer className="w-full bg-automotive-dark text-automotive-light py-8 mt-auto">
      <div className="container mx-auto px-4">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {/* Company Info */}
          <div>
            <h3 className="text-lg font-semibold mb-4">ApexCraft</h3>
            <p className="text-sm text-automotive-light/80">
              Professional Vehicle Configurator System for automotive dealers
              and customers.
            </p>
          </div>

          {/* Quick Links */}
          <div>
            <h4 className="text-lg font-semibold mb-4">Quick Links</h4>
            <ul className="space-y-2 text-sm">
              <li>
                <a href="#" className="hover:text-accent transition-colors">
                  Privacy Policy
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-accent transition-colors">
                  Terms of Service
                </a>
              </li>
              <li>
                <a href="#" className="hover:text-accent transition-colors">
                  Support
                </a>
              </li>
            </ul>
          </div>

          {/* Contact */}
          <div>
            <h4 className="text-lg font-semibold mb-4">Contact</h4>
            <p className="text-sm text-automotive-light/80">
              Vidyanidhis IT Institute
              <br />
              C-DAC Diploma Course
              <br />
              Email: jayant.Ponkshe@gmail.com
            </p>
          </div>
        </div>

        <div className="border-t border-automotive-light/20 mt-8 pt-8 text-center text-sm text-automotive-light/80">
          © {new Date().getFullYear()} ApexCraft Vehicle Configurator. All
          rights reserved.
        </div>
      </div>
    </footer>
  );
};
