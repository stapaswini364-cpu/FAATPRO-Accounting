import { Routes, Route } from "react-router-dom";

import MainLayout from "../layouts/MainLayout";

import ProtectedRoute from "../auth/ProtectedRoute";


// Public Pages

import Login from "../pages/Login";
import ForgotPassword from "../pages/ForgotPassword";
import ResetPassword from "../pages/ResetPassword";



// Protected Pages

import Dashboard from "../pages/Dashboard";
import Customers from "../pages/Customers";
import Settings from "../pages/Settings";
import Profile from "../pages/Profile";
import ChangePassword from "../pages/ChangePassword";



// Company Module

import CompanyList from "../pages/company/CompanyList";


// Branch Module

import BranchList from "../pages/branch/BranchList";




const AppRoutes = () => {

  return (

    <Routes>


      {/* PUBLIC */}

      <Route
        path="/login"
        element={<Login />}
      />


      <Route
        path="/forgot-password"
        element={<ForgotPassword />}
      />


      <Route
        path="/reset-password"
        element={<ResetPassword />}
      />



      {/* DASHBOARD */}

      <Route
        path="/"

        element={

          <ProtectedRoute>

            <MainLayout>

              <Dashboard />

            </MainLayout>

          </ProtectedRoute>

        }

      />




      {/* CUSTOMERS */}

      <Route
        path="/customers"

        element={

          <ProtectedRoute>

            <MainLayout>

              <Customers />

            </MainLayout>

          </ProtectedRoute>

        }

      />





      {/* COMPANY */}

      <Route
        path="/company"

        element={

          <ProtectedRoute>

            <MainLayout>

              <CompanyList />

            </MainLayout>

          </ProtectedRoute>

        }

      />





      {/* BRANCH */}

      <Route
        path="/branch"

        element={

          <ProtectedRoute>

            <MainLayout>

              <BranchList />

            </MainLayout>

          </ProtectedRoute>

        }

      />





      {/* SETTINGS */}

      <Route
        path="/settings"

        element={

          <ProtectedRoute>

            <MainLayout>

              <Settings />

            </MainLayout>

          </ProtectedRoute>

        }

      />





      {/* PROFILE */}

      <Route
        path="/profile"

        element={

          <ProtectedRoute>

            <MainLayout>

              <Profile />

            </MainLayout>

          </ProtectedRoute>

        }

      />





      {/* CHANGE PASSWORD */}

      <Route
        path="/change-password"

        element={

          <ProtectedRoute>

            <MainLayout>

              <ChangePassword />

            </MainLayout>

          </ProtectedRoute>

        }

      />





      {/* FALLBACK */}

      <Route
        path="*"
        element={<Login />}
      />


    </Routes>

  );

};


export default AppRoutes;