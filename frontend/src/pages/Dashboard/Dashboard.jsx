import { useEffect, useState } from "react";

import { Grid, Typography, Box, CircularProgress } from "@mui/material";

import KPICard from "./components/KPICard";

import RevenueChart from "./components/charts/RevenueChart";
import ExpenseChart from "./components/charts/ExpenseChart";

import { getDashboardSummary } from "../../api/dashboardApi";


const Dashboard = () => {

  const [loading, setLoading] = useState(true);

  const [dashboard, setDashboard] = useState({
    totalRevenue: 0,
    totalExpense: 0,
    netProfit: 0,
    cashBalance: 0
  });


  useEffect(() => {

    loadDashboard();

  }, []);



  const loadDashboard = async () => {

    try {

      const response = await getDashboardSummary();

      console.log("Dashboard API:", response.data);


      setDashboard(response.data);


    } catch (error) {

      console.error(
        "Dashboard loading failed",
        error
      );

    }
    finally {

      setLoading(false);

    }

  };



  if (loading) {

    return (

      <Box
        display="flex"
        justifyContent="center"
        mt={5}
      >

        <CircularProgress />

      </Box>

    );

  }



  return (

    <Box>


      <Typography
        variant="h4"
        mb={3}
        fontWeight="bold"
      >
        Finance Dashboard
      </Typography>



      {/* KPI CARDS */}

      <Grid container spacing={3}>


        <Grid item xs={12} sm={6} md={3}>

          <KPICard
            title="Total Revenue"
            value={`₹ ${dashboard.totalRevenue}`}
          />

        </Grid>



        <Grid item xs={12} sm={6} md={3}>

          <KPICard
            title="Total Expense"
            value={`₹ ${dashboard.totalExpense}`}
          />

        </Grid>



        <Grid item xs={12} sm={6} md={3}>

          <KPICard
            title="Net Profit"
            value={`₹ ${dashboard.netProfit}`}
          />

        </Grid>



        <Grid item xs={12} sm={6} md={3}>

          <KPICard
            title="Cash Balance"
            value={`₹ ${dashboard.cashBalance}`}
          />

        </Grid>


      </Grid>





      {/* CHARTS */}


      <Grid
        container
        spacing={3}
        mt={2}
      >


        <Grid item xs={12} md={6}>

          <Box
            sx={{
              height:300,
              borderRadius:2,
              boxShadow:3,
              p:3,
              backgroundColor:"white"
            }}
          >

            <Typography
              variant="h6"
              mb={2}
            >
              Revenue Chart
            </Typography>


            <RevenueChart />

          </Box>


        </Grid>





        <Grid item xs={12} md={6}>


          <Box
            sx={{
              height:300,
              borderRadius:2,
              boxShadow:3,
              p:3,
              backgroundColor:"white"
            }}
          >


            <Typography
              variant="h6"
              mb={2}
            >
              Expense Chart
            </Typography>


            <ExpenseChart />


          </Box>


        </Grid>



      </Grid>





      {/* TRANSACTIONS */}


      <Box

        mt={3}

        sx={{
          height:250,
          borderRadius:2,
          boxShadow:3,
          p:3,
          backgroundColor:"white"
        }}

      >

        <Typography variant="h6">
          Recent Transactions
        </Typography>


      </Box>



    </Box>

  );

};


export default Dashboard;