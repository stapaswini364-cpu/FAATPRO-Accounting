import { useEffect, useState } from "react";

import {
  Card,
  CardContent,
  Grid,
  Typography,
  Box
} from "@mui/material";

import { getDashboardSummary } from "../../api/dashboardApi";


const Dashboard = () => {

  const [summary, setSummary] = useState(null);


  useEffect(() => {

    loadDashboard();

  }, []);



  const loadDashboard = async () => {

    try {

      const response = await getDashboardSummary();

      console.log(
        "Dashboard API Response:",
        response.data
      );


      setSummary(
        response.data.data ?? response.data
      );

    }
    catch(error) {

      console.log(
        "Dashboard API Error:",
        error.response?.data || error.message
      );

    }

  };



  if (!summary) {

    return (

      <Box>

        <Typography>
          Loading Dashboard...
        </Typography>

      </Box>

    );

  }



  return (

    <Box>


      <Typography
        variant="h4"
        mb={3}
      >
        FAATPRO Dashboard
      </Typography>



      <Grid container spacing={3}>


        <Grid item xs={12} md={3}>

          <Card>

            <CardContent>

              <Typography>
                Total Customers
              </Typography>


              <Typography variant="h5">

                {summary.totalCustomers ?? 0}

              </Typography>


            </CardContent>

          </Card>

        </Grid>





        <Grid item xs={12} md={3}>

          <Card>

            <CardContent>

              <Typography>
                Total Vendors
              </Typography>


              <Typography variant="h5">

                {summary.totalVendors ?? 0}

              </Typography>


            </CardContent>

          </Card>

        </Grid>





        <Grid item xs={12} md={3}>

          <Card>

            <CardContent>

              <Typography>
                Total Revenue
              </Typography>


              <Typography variant="h5">

                ₹ {summary.totalRevenue ?? 0}

              </Typography>


            </CardContent>

          </Card>

        </Grid>





        <Grid item xs={12} md={3}>

          <Card>

            <CardContent>

              <Typography>
                Total Expense
              </Typography>


              <Typography variant="h5">

                ₹ {summary.totalExpense ?? 0}

              </Typography>


            </CardContent>

          </Card>

        </Grid>



      </Grid>


    </Box>

  );

};


export default Dashboard;