import { useEffect, useState } from "react";

import {
    Grid,
    Typography,
    Box,
    CircularProgress,
    Paper
} from "@mui/material";


import TrendingUpIcon from "@mui/icons-material/TrendingUp";
import TrendingDownIcon from "@mui/icons-material/TrendingDown";
import AccountBalanceWalletIcon from "@mui/icons-material/AccountBalanceWallet";
import PeopleIcon from "@mui/icons-material/People";
import StoreIcon from "@mui/icons-material/Store";
import PaymentsIcon from "@mui/icons-material/Payments";


import KPICard from "./components/KPICard";


import RevenueChart from "./components/charts/RevenueChart";
import ExpenseChart from "./components/charts/ExpenseChart";


import QuickActions from "./components/dashboard/QuickActions";
import RecentTransactions from "./components/dashboard/RecentTransactions";
import AccountSummary from "./components/dashboard/AccountSummary";


import { getDashboardSummary } from "../../api/dashboardApi";



const Dashboard = () => {


    const [loading,setLoading] = useState(true);



    const [dashboard,setDashboard] = useState({

        totalRevenue:0,

        totalExpense:0,

        netProfit:0,

        cashBalance:0,

        customers:0,

        vendors:0,

        receivable:0,

        payable:0

    });





    useEffect(()=>{

        loadDashboard();

    },[]);





    const loadDashboard = async()=>{


        try{


            const response =
                await getDashboardSummary();


            console.log(
                "Dashboard API:",
                response.data
            );


            setDashboard({

                ...dashboard,

                ...response.data

            });


        }
        catch(error)
        {

            console.error(
                error
            );

        }
        finally
        {

            setLoading(false);

        }


    };






    if(loading)
    {

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



            {/* HEADER */}


            <Box mb={4}>


                <Typography

                    variant="h4"

                    fontWeight={700}

                >

                    FAATPRO Finance Dashboard

                </Typography>



                <Typography

                    color="text.secondary"

                >

                    Business overview and accounting summary

                </Typography>


            </Box>








            {/* KPI SECTION */}



            <Grid
                container
                spacing={3}
            >



                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Total Revenue"

                        value={`₹ ${dashboard.totalRevenue}`}

                        icon={
                            <TrendingUpIcon />
                        }

                    />

                </Grid>





                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Total Expense"

                        value={`₹ ${dashboard.totalExpense}`}

                        icon={
                            <TrendingDownIcon />
                        }

                    />

                </Grid>






                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Net Profit"

                        value={`₹ ${dashboard.netProfit}`}

                        icon={
                            <PaymentsIcon />
                        }

                    />

                </Grid>






                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Cash Balance"

                        value={`₹ ${dashboard.cashBalance}`}

                        icon={
                            <AccountBalanceWalletIcon />
                        }

                    />

                </Grid>








                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Customers"

                        value={dashboard.customers}

                        icon={
                            <PeopleIcon />
                        }

                    />

                </Grid>







                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Vendors"

                        value={dashboard.vendors}

                        icon={
                            <StoreIcon />
                        }

                    />

                </Grid>








                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Receivable"

                        value={`₹ ${dashboard.receivable}`}

                    />

                </Grid>







                <Grid item xs={12} sm={6} md={3}>

                    <KPICard

                        title="Payable"

                        value={`₹ ${dashboard.payable}`}

                    />

                </Grid>



            </Grid>









            {/* CHART SECTION */}



            <Grid

                container

                spacing={3}

                mt={2}

            >



                <Grid

                    item

                    xs={12}

                    md={6}

                >


                    <Paper

                        sx={{

                            p:3,

                            height:350

                        }}

                    >


                        <Typography

                            variant="h6"

                            mb={2}

                        >

                            Revenue Overview

                        </Typography>


                        <RevenueChart />


                    </Paper>


                </Grid>








                <Grid

                    item

                    xs={12}

                    md={6}

                >


                    <Paper

                        sx={{

                            p:3,

                            height:350

                        }}

                    >


                        <Typography

                            variant="h6"

                            mb={2}

                        >

                            Expense Overview

                        </Typography>


                        <ExpenseChart />


                    </Paper>


                </Grid>



            </Grid>









            {/* LOWER SECTION */}



            <Grid

                container

                spacing={3}

                mt={2}

            >


                <Grid

                    item

                    xs={12}

                    md={8}

                >

                    <RecentTransactions />

                </Grid>





                <Grid

                    item

                    xs={12}

                    md={4}

                >

                    <QuickActions />

                </Grid>



            </Grid>








            <Box mt={3}>

                <AccountSummary />

            </Box>





        </Box>

    );


};


export default Dashboard;