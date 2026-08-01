import { useEffect, useState } from "react";

import {
    Box,
    Button,
    CircularProgress,
    IconButton,
    Paper,
    Stack,
    Typography,
    Snackbar,
    Alert,
} from "@mui/material";

import {
    DataGrid,
} from "@mui/x-data-grid";


import AddIcon from "@mui/icons-material/Add";
import RefreshIcon from "@mui/icons-material/Refresh";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import VisibilityIcon from "@mui/icons-material/Visibility";
import PrintIcon from "@mui/icons-material/Print";


import journalEntryApi from "../../api/journalEntryApi";



const JournalEntryList = () => {


    const [rows, setRows] = useState([]);

    const [loading, setLoading] = useState(false);

    const [message, setMessage] = useState("");

    const [openSnackbar, setOpenSnackbar] = useState(false);



    const loadJournalEntries = async () => {

        try {

            setLoading(true);

            const data = await journalEntryApi.getAll();


            setRows(
                data.map((item) => ({
                    id: item.id,
                    voucherNo:
                        item.voucherNo ||
                        item.voucherNumber ||
                        "-",

                    date:
                        item.date ||
                        item.voucherDate ||
                        "-",

                    narration:
                        item.narration ||
                        "-",

                    debit:
                        item.totalDebit ||
                        0,

                    credit:
                        item.totalCredit ||
                        0,

                }))
            );


        }
        catch (error) {

            console.error(error);

            setMessage(
                "Failed to load Journal Entries"
            );

            setOpenSnackbar(true);

        }
        finally {

            setLoading(false);

        }

    };



    useEffect(() => {

        loadJournalEntries();

    }, []);





    const handleDelete = async (id) => {


        const confirmDelete =
            window.confirm(
                "Delete this Journal Entry?"
            );


        if (!confirmDelete)
            return;



        try {


            await journalEntryApi.delete(id);


            setMessage(
                "Journal Entry deleted successfully"
            );


            setOpenSnackbar(true);


            loadJournalEntries();


        }
        catch(error){


            console.error(error);


            setMessage(
                "Delete failed"
            );


            setOpenSnackbar(true);


        }

    };





    const columns = [

        {
            field: "voucherNo",
            headerName: "Voucher No",
            width:150
        },


        {
            field:"date",
            headerName:"Date",
            width:150
        },


        {
            field:"narration",
            headerName:"Narration",
            width:300
        },


        {
            field:"debit",
            headerName:"Debit",
            width:120
        },


        {
            field:"credit",
            headerName:"Credit",
            width:120
        },


        {
            field:"actions",
            headerName:"Actions",
            width:220,

            renderCell:(params)=>(
                
                <Stack direction="row">


                    <IconButton color="primary">

                        <VisibilityIcon />

                    </IconButton>



                    <IconButton color="success">

                        <EditIcon />

                    </IconButton>



                    <IconButton color="info">

                        <PrintIcon />

                    </IconButton>



                    <IconButton
                        color="error"
                        onClick={() =>
                            handleDelete(
                                params.row.id
                            )
                        }
                    >

                        <DeleteIcon />

                    </IconButton>



                </Stack>

            )

        }

    ];






    return (

        <Box sx={{p:3}}>


            <Paper
                elevation={3}
                sx={{p:3}}
            >


                <Stack
                    direction="row"
                    justifyContent="space-between"
                    mb={3}
                >


                    <Typography
                        variant="h5"
                        fontWeight={600}
                    >
                        Journal Entries
                    </Typography>



                    <Stack
                        direction="row"
                        spacing={2}
                    >


                        <Button
                            variant="outlined"
                            startIcon={<RefreshIcon />}
                            onClick={
                                loadJournalEntries
                            }
                        >
                            Refresh
                        </Button>



                        <Button
                            variant="contained"
                            startIcon={<AddIcon />}
                        >
                            New Voucher
                        </Button>


                    </Stack>


                </Stack>





                {
                    loading ?


                    <Box
                        display="flex"
                        justifyContent="center"
                        p={5}
                    >

                        <CircularProgress />

                    </Box>


                    :


                    <DataGrid

                        rows={rows}

                        columns={columns}

                        pageSizeOptions={
                            [5,10,25]
                        }

                        initialState={{

                            pagination:{
                                paginationModel:{
                                    pageSize:10,
                                    page:0
                                }
                            }

                        }}

                        autoHeight

                        disableRowSelectionOnClick

                    />

                }



            </Paper>





            <Snackbar

                open={openSnackbar}

                autoHideDuration={3000}

                onClose={() =>
                    setOpenSnackbar(false)
                }

            >

                <Alert severity="success">

                    {message}

                </Alert>


            </Snackbar>



        </Box>

    );


};



export default JournalEntryList;