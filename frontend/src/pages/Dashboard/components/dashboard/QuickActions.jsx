import {
    Paper,
    Button,
    Stack
} from "@mui/material";


import AddIcon from "@mui/icons-material/Add";



const QuickActions = () => {


    return (

        <Paper
            sx={{
                p:3,
                borderRadius:3
            }}
            elevation={3}
        >


            <Stack
                spacing={1}
            >

                <Button
                    variant="contained"
                    startIcon={<AddIcon />}
                >
                    New Journal Entry
                </Button>


                <Button
                    variant="outlined"
                >
                    Payment Voucher
                </Button>


                <Button
                    variant="outlined"
                >
                    Receipt Voucher
                </Button>


                <Button
                    variant="outlined"
                >
                    Create Ledger
                </Button>


            </Stack>


        </Paper>

    );

};



export default QuickActions;