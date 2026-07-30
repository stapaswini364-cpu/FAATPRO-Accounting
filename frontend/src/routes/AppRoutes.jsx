import { Routes, Route } from "react-router-dom";

import MainLayout from "../layouts/MainLayout";

import ProtectedRoute from "../redux/auth/ProtectedRoute";


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



const AppRoutes = () => {
  return (
    <Routes>


      {/* =========================
          PUBLIC ROUTES
      ========================== */}


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





      {/* =========================
          PROTECTED ROUTES
      ========================== */}



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







      {/* =========================
          COMPANY MODULE
      ========================== */}


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





      {/* Default Redirect */}

      <Route
        path="*"

        element={<Login />}

      />


    </Routes>
  );
};


export default AppRoutes;