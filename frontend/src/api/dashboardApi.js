import api from "./axios";


// =====================================
// Dashboard Summary
// GET /api/dashboard/summary
// =====================================

export const getDashboardSummary = async()=>{

    const response =
        await api.get(
            "/dashboard/summary"
        );

    return response.data;

};




// =====================================
// Recent Transactions
// GET /api/dashboard/recent-transactions
// =====================================

export const getRecentTransactions = async()=>{

    const response =
        await api.get(
            "/dashboard/recent-transactions"
        );

    return response.data;

};




// =====================================
// Account Summary
// GET /api/dashboard/account-summary
// =====================================

export const getAccountSummary = async()=>{

    const response =
        await api.get(
            "/dashboard/account-summary"
        );

    return response.data;

};
// =====================================
// Revenue Chart
// GET /api/dashboard/revenue-chart
// =====================================

export const getRevenueChart = async()=>{

    const response =
        await api.get(
            "/dashboard/revenue-chart"
        );

    return response.data;

};




// =====================================
// Expense Chart
// GET /api/dashboard/expense-chart
// =====================================

export const getExpenseChart = async()=>{

    const response =
        await api.get(
            "/dashboard/expense-chart"
        );

    return response.data;

};
// =====================================
// Cash Flow Chart
// GET /api/dashboard/cash-flow-chart
// =====================================

export const getCashFlowChart = async()=>{

    const response =
        await api.get(
            "/dashboard/cash-flow-chart"
        );

    return response.data;

};