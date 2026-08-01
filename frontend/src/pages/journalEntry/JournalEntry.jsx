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


    return (

        <Box sx={{ p: 3 }}>

            <Paper
                elevation={3}
                sx={{ p: 3 }}
            >

                <Box
                    sx={{
                        display: "flex",
                        justifyContent: "space-between",
                        alignItems: "center",
                        mb: 3,
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
                                onClick={() =>
                                    setShowForm(true)
                                }
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
                                onClick={() =>
                                    setShowForm(false)
                                }
                            >
                                Back
                            </Button>

                        )
                    }


                </Box>



                {
                    showForm ? (

                        <JournalEntryForm
                            onCancel={() =>
                                setShowForm(false)
                            }
                        />

                    ) : (

                        <JournalEntryList />

                    )
                }


            </Paper>

        </Box>

    );

};


export default JournalEntry;