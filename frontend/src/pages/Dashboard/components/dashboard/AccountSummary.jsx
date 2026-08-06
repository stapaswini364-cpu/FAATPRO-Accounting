import { useEffect, useState } from "react";

import {
    Paper,
    Grid,
    CircularProgress,
    Box,
    Typography
} from "@mui/material";


import { getDashboardSummary } from "../../../../api/dashboardApi";



const AccountSummary = () => {


    const [loading,setLoading] = useState(true);


    const [accounts,setAccounts] = useState([
        {
            title:"Cash",
            value:0
        },
        {
            title:"Bank",
            value:0
        },
        {
            title:"Receivable",
            value:0
        },
        {
            title:"Payable",
            value:0
        }
    ]);





    useEffect(()=>{

        loadSummary();

    },[]);






    const loadSummary = async()=>{


        try{


            const response =
                await getDashboardSummary();



            const data =
                response?.data
                ??
                response;



            console.log(
                "Account Summary API:",
                data
            );





            setAccounts([

                {
                    title:"Cash",
                    value:data.cashBalance ?? 0
                },


                {
                    title:"Bank",
                    value:data.bankBalance ?? 0
                },


                {
                    title:"Receivable",
                    value:data.receivable ?? 0
                },


                {
                    title:"Payable",
                    value:data.payable ?? 0
                }

            ]);



        }
        catch(error){

            console.error(
                "Account Summary Error",
                error
            );

        }
        finally{

            setLoading(false);

        }

    };







    if(loading)
    {
        return(

            <Box
                display="flex"
                justifyContent="center"
                p={3}
            >

                <CircularProgress size={30}/>

            </Box>

        );
    }









    return(

        <Paper

            sx={{
                p:3,
                borderRadius:3
            }}

            elevation={3}

        >



            <Grid

                container

                spacing={2}

            >


            {
                accounts.map((item,index)=>(


                    <Grid

                        item

                        xs={12}

                        sm={6}

                        md={3}

                        key={index}

                    >


                        <Typography

                            color="text.secondary"

                        >

                            {item.title}

                        </Typography>




                        <Typography

                            variant="h6"

                            fontWeight={700}

                        >

                            ₹ {Number(item.value).toLocaleString()}


                        </Typography>


                    </Grid>


                ))
            }


            </Grid>


        </Paper>


    );


};



export default AccountSummary;