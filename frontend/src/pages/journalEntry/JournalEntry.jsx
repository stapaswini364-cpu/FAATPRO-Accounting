import { useState } from "react";

import {
    Box,
    Paper,
    Typography,
    Button,
} from "@mui/material";

import AddIcon from "@mui/icons-material/Add";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";


import JournalEntryList from "./JournalEntryList";
import JournalEntryForm from "./components/JournalEntryForm";


const JournalEntry = () => {


    const [showForm, setShowForm] = useState(false);

    const [editId, setEditId] = useState(null);



    const handleNewVoucher = () => {

        setEditId(null);

        setShowForm(true);

    };



    const handleEdit = (id) => {

        setEditId(id);

        setShowForm(true);

    };



    const handleBack = () => {

        setEditId(null);

        setShowForm(false);

    };



    return (

        <Box sx={{ p:3 }}>

            <Paper
                elevation={3}
                sx={{p:3}}
            >


                <Box
                    sx={{
                        display:"flex",
                        justifyContent:"space-between",
                        alignItems:"center",
                        mb:3
                    }}
                >

                    <Typography
                        variant="h4"
                        fontWeight={600}
                    >
                        Journal Entry
                    </Typography>



                    {
                        !showForm && (

                            <Button
                                variant="contained"
                                startIcon={<AddIcon />}
                                onClick={handleNewVoucher}
                            >
                                New Voucher
                            </Button>

                        )
                    }



                    {
                        showForm && (

                            <Button
                                variant="outlined"
                                startIcon={<ArrowBackIcon />}
                                onClick={handleBack}
                            >
                                Back
                            </Button>

                        )
                    }


                </Box>





                {
                    showForm ? (

                        <JournalEntryForm

                            editId={editId}

                            onCancel={handleBack}

                        />


                    )
                    :
                    (

                        <JournalEntryList

                            onEdit={handleEdit}

                        />

                    )

                }



            </Paper>


        </Box>

    );

};


export default JournalEntry;