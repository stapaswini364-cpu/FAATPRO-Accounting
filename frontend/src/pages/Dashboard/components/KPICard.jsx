import {
    Paper,
    Box,
    Typography
} from "@mui/material";


const KPICard = ({
    title,
    value,
    icon
}) => {


    return (

        <Paper

            elevation={3}

            sx={{

                p:3,

                borderRadius:3,

                height:"100%"

            }}

        >

            <Box
                display="flex"
                justifyContent="space-between"
                alignItems="center"
            >


                <Box>

                    <Typography
                        color="text.secondary"
                        variant="body2"
                    >
                        {title}
                    </Typography>


                    <Typography

                        variant="h5"

                        fontWeight={700}

                        mt={1}

                    >
                        {value}
                    </Typography>


                </Box>


                {
                    icon
                }


            </Box>


        </Paper>

    );

};


export default KPICard;