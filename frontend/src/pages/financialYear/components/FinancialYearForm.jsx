import { useEffect, useState } from "react";

import {
    Box,
    Button,
    Paper,
    TextField,
    Typography
} from "@mui/material";

import financialYearApi from "../../../api/financialYearApi";


const initialForm = {

    companyId: "",
    yearName: "",
    startDate: "",
    endDate: "",
    isCurrent: false

};



export default function FinancialYearForm({
    onSuccess,
    editData
})
{

    const [form,setForm] = useState(initialForm);



    useEffect(()=>{

        if(editData)
        {
            setForm({

                companyId: editData.companyId || "",
                yearName: editData.yearName || "",
                startDate: editData.startDate || "",
                endDate: editData.endDate || "",
                isCurrent: editData.isCurrent || false

            });
        }
        else
        {
            setForm(initialForm);
        }

    },[editData]);




    const handleChange=(e)=>{

        const {name,value} = e.target;


        setForm({

            ...form,

            [name]: value

        });

    };




    const handleSubmit=async(e)=>{

        e.preventDefault();


        try{


            if(editData)
            {

                await financialYearApi.update(
                    editData.id,
                    form
                );

            }
            else
            {

                await financialYearApi.create(
                    form
                );

            }


            setForm(initialForm);


            if(onSuccess)
                onSuccess();


        }
        catch(error)
        {

            console.error(
                "Financial Year Save Error",
                error.response?.data || error.message
            );

        }

    };




    return (

        <Paper sx={{p:3,mb:3}}>


            <Typography
                variant="h6"
                mb={2}
            >
                {
                    editData
                    ?
                    "Edit Financial Year"
                    :
                    "Create Financial Year"
                }

            </Typography>



            <Box
                component="form"
                onSubmit={handleSubmit}
                sx={{
                    display:"grid",
                    gap:2
                }}
            >


                <TextField

                    label="Company Id"

                    name="companyId"

                    value={form.companyId}

                    onChange={handleChange}

                    required

                />



                <TextField

                    label="Year Name"

                    name="yearName"

                    value={form.yearName}

                    onChange={handleChange}

                    placeholder="2026-2027"

                    required

                />



                <TextField

                    label="Start Date"

                    type="date"

                    name="startDate"

                    value={form.startDate}

                    onChange={handleChange}

                    InputLabelProps={{
                        shrink:true
                    }}

                    required

                />



                <TextField

                    label="End Date"

                    type="date"

                    name="endDate"

                    value={form.endDate}

                    onChange={handleChange}

                    InputLabelProps={{
                        shrink:true
                    }}

                    required

                />



                <Button

                    variant="contained"

                    type="submit"

                >

                    Save Financial Year

                </Button>


            </Box>


        </Paper>

    );

}