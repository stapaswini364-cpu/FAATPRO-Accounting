import { useState } from "react";

import {
    Box,
    Button,
    TextField,
    Grid,
    Paper,
    Typography
} from "@mui/material";


import companyApi from "../../../api/companyApi";



export default function CompanyForm({ 
    onSuccess,
    editData = null
})
{


    const [formData,setFormData] = useState({

        companyCode: editData?.companyCode || "",

        companyName: editData?.companyName || "",

        legalName: editData?.legalName || "",

        gstNumber: editData?.gstNumber || "",

        panNumber: editData?.panNumber || "",

        cinNumber: editData?.cinNumber || "",

        email: editData?.email || "",

        phone: editData?.phone || "",

        website: editData?.website || "",

        addressLine1: editData?.addressLine1 || "",

        addressLine2: editData?.addressLine2 || "",

        city: editData?.city || "",

        state: editData?.state || "",

        country: editData?.country || "",

        postalCode: editData?.postalCode || "",

        currencyCode: editData?.currencyCode || "",

        financialYearStartMonth:
            editData?.financialYearStartMonth || 4

    });



    const handleChange = (e)=>{

        setFormData({

            ...formData,

            [e.target.name]: e.target.value

        });

    };





    const handleSubmit = async(e)=>{

        e.preventDefault();


        try{


            if(editData)
            {

                await companyApi.update(
                    editData.id,
                    formData
                );

            }
            else
            {

                await companyApi.create(
                    formData
                );

            }



            if(onSuccess)
                onSuccess();



        }
        catch(error)
        {

            console.error(
                "Company save failed",
                error
            );

        }

    };







    return (

        <Paper
            sx={{
                p:3
            }}
        >


            <Typography
                variant="h6"
                mb={3}
            >
                {
                    editData
                    ?
                    "Update Company"
                    :
                    "Create Company"
                }

            </Typography>




            <Box
                component="form"
                onSubmit={handleSubmit}
            >


                <Grid container spacing={2}>


                    {
                        Object.keys(formData)
                        .map((key)=>(

                            <Grid
                                item
                                xs={12}
                                md={6}
                                key={key}
                            >

                                <TextField

                                    fullWidth

                                    label={key}

                                    name={key}

                                    value={formData[key]}

                                    onChange={handleChange}

                                />

                            </Grid>

                        ))
                    }



                    <Grid
                        item
                        xs={12}
                    >

                        <Button

                            type="submit"

                            variant="contained"

                        >

                            Save Company

                        </Button>


                    </Grid>



                </Grid>


            </Box>


        </Paper>

    );

}