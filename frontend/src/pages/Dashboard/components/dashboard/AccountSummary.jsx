import {
    Paper,
    Typography,
    Grid
} from "@mui/material";


const AccountSummary = () => {


    const accounts = [

        {
            title:"Cash",
            value:"₹ 0"
        },

        {
            title:"Bank",
            value:"₹ 0"
        },

        {
            title:"Receivable",
            value:"₹ 0"
        },

        {
            title:"Payable",
            value:"₹ 0"
        }

    ];



    return (

        <Paper
            sx={{
                p:3,
                borderRadius:3
            }}
            elevation={3}
        >


            <Typography
                variant="h6"
                mb={2}
                fontWeight={600}
            >
                Account Summary
            </Typography>



            <Grid
                container
                spacing={2}
            >

                {
                    accounts.map(
                        (item,index)=>(

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
                                    {item.value}
                                </Typography>


                            </Grid>

                        )
                    )
                }


            </Grid>


        </Paper>

    );

};


export default AccountSummary;