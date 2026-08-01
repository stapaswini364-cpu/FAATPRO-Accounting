import { Box, Paper, Typography, Button } from "@mui/material";
import AddIcon from "@mui/icons-material/Add";

const JournalEntry = () => {
    return (
        <Box sx={{ p: 3 }}>
            <Paper elevation={3} sx={{ p: 3 }}>

                <Box
                    sx={{
                        display: "flex",
                        justifyContent: "space-between",
                        alignItems: "center",
                        mb: 3
                    }}
                >
                    <Typography
                        variant="h4"
                        fontWeight={600}
                    >
                        Journal Entry
                    </Typography>


                    <Button
                        variant="contained"
                        startIcon={<AddIcon />}
                    >
                        New Voucher
                    </Button>

                </Box>


                <Typography>
                    Journal Entry Module Loaded Successfully
                </Typography>


            </Paper>
        </Box>
    );
};


export default JournalEntry;