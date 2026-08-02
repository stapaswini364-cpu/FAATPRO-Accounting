import api from "./axios";


// Dashboard Summary
export const getDashboardSummary = () => {
  return api.get("/reports/dashboard-summary");
};


// Trial Balance
export const getTrialBalance = (params) => {
  return api.get("/reports/trial-balance", { params });
};


// Profit & Loss
export const getProfitAndLoss = (params) => {
  return api.get("/reports/profit-loss", { params });
};


// Balance Sheet
export const getBalanceSheet = (params) => {
  return api.get("/reports/balance-sheet", { params });
};


// General Ledger
export const getGeneralLedger = (params) => {
  return api.get("/reports/general-ledger", { params });
};


// Ledger Statement
export const getLedgerReport = (ledgerId) => {
  return api.get(`/Ledger/${ledgerId}`);
};