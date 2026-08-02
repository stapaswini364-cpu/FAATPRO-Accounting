import { Routes, Route } from "react-router-dom";


import MainLayout from "../layouts/MainLayout";
import ProtectedRoute from "../auth/ProtectedRoute";



// ================= PUBLIC =================

import Login from "../pages/Login";
import ForgotPassword from "../pages/ForgotPassword";
import ResetPassword from "../pages/ResetPassword";



// ================= PROTECTED =================

import Dashboard from "../pages/Dashboard";
import Customers from "../pages/Customers";
import Settings from "../pages/Settings";
import Profile from "../pages/Profile";
import ChangePassword from "../pages/ChangePassword";



// ================= COMPANY =================

import CompanyList from "../pages/company/CompanyList";



// ================= BRANCH =================

import BranchList from "../pages/branch/BranchList";



// ================= FINANCIAL =================

import FinancialYear from "../pages/financialYear";



// ================= ACCOUNT =================

import AccountHead from "../pages/accountHead";

import AccountGroup from "../pages/accountGroup/AccountGroup";

import AccountSubGroup from "../pages/accountSubGroup/AccountSubGroup";

import Ledger from "../pages/ledger/Ledger";



// ================= CHART =================

import ChartOfAccounts from "../pages/chartOfAccounts/ChartOfAccounts";



// ================= JOURNAL ENTRY =================

import JournalEntry from "../pages/journalEntry/JournalEntry";



// ================= REPORTS =================

import LedgerReport from "../pages/reports/ledger/LedgerReport";





const AppRoutes = () => {


return (

<Routes>





{/* ================= LOGIN ================= */}


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







{/* ================= DASHBOARD ================= */}


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








{/* ================= CUSTOMERS ================= */}


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








{/* ================= COMPANY ================= */}


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







{/* ================= BRANCH ================= */}


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







{/* ================= FINANCIAL YEAR ================= */}


<Route

path="/financial-year"

element={

<ProtectedRoute>

<MainLayout>

<FinancialYear />

</MainLayout>

</ProtectedRoute>

}

/>








{/* ================= ACCOUNT HEAD ================= */}


<Route

path="/account-head"

element={

<ProtectedRoute>

<MainLayout>

<AccountHead />

</MainLayout>

</ProtectedRoute>

}

/>








{/* ================= ACCOUNT GROUP ================= */}


<Route

path="/account-group"

element={

<ProtectedRoute>

<MainLayout>

<AccountGroup />

</MainLayout>

</ProtectedRoute>

}

/>








{/* ================= ACCOUNT SUB GROUP ================= */}


<Route

path="/account-sub-group"

element={

<ProtectedRoute>

<MainLayout>

<AccountSubGroup />

</MainLayout>

</ProtectedRoute>

}

/>








{/* ================= LEDGER ================= */}


<Route

path="/ledger"

element={

<ProtectedRoute>

<MainLayout>

<Ledger />

</MainLayout>

</ProtectedRoute>

}

/>









{/* ================= CHART OF ACCOUNTS ================= */}


<Route

path="/chart-of-accounts"

element={

<ProtectedRoute>

<MainLayout>

<ChartOfAccounts />

</MainLayout>

</ProtectedRoute>

}

/>









{/* ================= JOURNAL ENTRY ================= */}


<Route

path="/journal-entry"

element={

<ProtectedRoute>

<MainLayout>

<JournalEntry />

</MainLayout>

</ProtectedRoute>

}

/>









{/* ================= LEDGER REPORT ================= */}


<Route

path="/reports/ledger"

element={

<ProtectedRoute>

<MainLayout>

<LedgerReport />

</MainLayout>

</ProtectedRoute>

}

/>









{/* ================= SETTINGS ================= */}


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








{/* ================= PROFILE ================= */}


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








{/* ================= CHANGE PASSWORD ================= */}


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








{/* ================= DEFAULT ================= */}


<Route

path="*"

element={<Login />}

/>




</Routes>


);


};


export default AppRoutes;