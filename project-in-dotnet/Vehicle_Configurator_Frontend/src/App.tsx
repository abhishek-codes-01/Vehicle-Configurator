import { Toaster } from "@/components/ui/toaster";
import { Toaster as Sonner } from "@/components/ui/sonner";
import { TooltipProvider } from "@/components/ui/tooltip";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./context/AuthProvider";
import ProtectedRoute from "./pages/ProtectedRoute";
import { Header } from "./components/layout/Header";
import Index from "./pages/Index";
import NotFound from "./pages/NotFound";
import Selector from "./pages/Selector";
import Contact from "./pages/Contact";
import About from "./pages/About";
import RegistrationForm from "./pages/RegistrationForm";
import SignInForm from "./pages/SignInForm";
import React, { Suspense } from "react";

const queryClient = new QueryClient();
const ModelView = React.lazy(() => import("./pages/ModelView"));
const App = () => (
  <QueryClientProvider client={queryClient}>
    <TooltipProvider>
      <Toaster />
      <Sonner />
      <BrowserRouter>
        <AuthProvider>
          <Routes>
            {/* Auth routes without header */}
            <Route path="/login" element={<SignInForm />} />
            <Route path="/register" element={<RegistrationForm />} />

            {/* All other routes with single header */}
            <Route
              path="*"
              element={
                <div className="min-h-screen bg-background">
                  <Header />
                  <main>
                    <Routes>
                      <Route path="/" element={<Index />} />
                      <Route path="/about" element={<About />} />
                      <Route path="/contact" element={<Contact />} />

                      {/* Protected Routes */}
                      <Route
                        path="/selector"
                        element={
                          <ProtectedRoute>
                            <Selector />
                          </ProtectedRoute>
                        }
                      />
                      <Route
                        path="/modelview/:modelId"
                        element={
                          <ProtectedRoute>
                            <Suspense fallback={<div>Loading model...</div>}>
                              <ModelView />
                            </Suspense>
                          </ProtectedRoute>
                        }
                      />

                      <Route
                        path="/unauthorized"
                        element={
                          <div className="container mx-auto px-4 py-20 text-center">
                            <h1 className="text-2xl font-bold text-destructive mb-4">
                              Unauthorized Access
                            </h1>
                            <p className="text-muted-foreground">
                              You don't have permission to access this page.
                            </p>
                          </div>
                        }
                      />

                      <Route path="*" element={<NotFound />} />
                    </Routes>
                  </main>
                </div>
              }
            />
          </Routes>
        </AuthProvider>
      </BrowserRouter>
    </TooltipProvider>
  </QueryClientProvider>
);

export default App;
