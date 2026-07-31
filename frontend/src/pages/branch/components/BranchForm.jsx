import { useEffect, useState } from "react";

import {
    Box,
    Button,
    Paper,
    TextField,
    Typography
} from "@mui/material";

import branchApi from "../../../api/branchApi";
import companyApi from "../../../api/companyApi";


const initialForm = {

    companyId: "",
    branchCode: "",
    branchName: "",
    address: "",
    city: "",
    state: "",
    country: "",
    phone: "",
    email: ""

};



export default function BranchForm({
    onSuccess,
    editData
})
{

    const [form,setForm] = useState(initialForm);

    const [companies,setCompanies] = useState([]);




    useEffect(()=>{

        loadCompanies();

    },[]);





    const loadCompanies = async()=>{

        try{

            const data = await companyApi.getAll();


            console.log(
                "COMPANY DATA:",
                data
            );


            setCompanies(

                Array.isArray(data)
                ?
                data
                :
                []

            );


        }
        catch(error){

            console.error(
                "Company loading failed",
                error
            );

        }

    };







    useEffect(()=>{


        if(editData)
        {

            setForm({

                companyId: editData.companyId || "",
                branchCode: editData.branchCode || "",
                branchName: editData.branchName || "",
                address: editData.address || "",
                city: editData.city || "",
                state: editData.state || "",
                country: editData.country || "",
                phone: editData.phone || "",
                email: editData.email || ""

            });


        }
        else
        {

            setForm(initialForm);

        }


    },[editData]);







    const handleChange=(e)=>{

        setForm({

            ...form,

            [e.target.name]: e.target.value

        });

    };







    const handleSubmit=async(e)=>{

        e.preventDefault();


        console.log(
            "SAVE PAYLOAD:",
            form
        );


        try{


            if(editData)
            {

                await branchApi.update(

                    editData.id,

                    form

                );

            }
            else
            {

                await branchApi.create(

                    form

                );

            }



            setForm(initialForm);


            if(onSuccess)
            {
                onSuccess();
            }


        }
        catch(error)
        {

            console.error(
                "Branch save error:",
                error.response?.data || error.message
            );

        }


    };







    return (

        <Paper

            sx={{
                p:3,
                mb:3
            }}

        >



            <Typography

                variant="h6"

                mb={2}

            >

                {
                    editData
                    ?
                    "Edit Branch"
                    :
                    "Create Branch"
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






                <Box>


                    <label>

                        Company *

                    </label>



                    <select

                        name="companyId"

                        value={form.companyId}

                        onChange={handleChange}

                        required

                        style={{

                            width:"100%",

                            height:"56px",

                            marginTop:"8px",

                            padding:"10px",

                            fontSize:"16px"

                        }}

                    >


                        <option value="">

                            Select Company

                        </option>



                        {

                            companies.map((company)=>(


                                <option

                                    key={company.id}

                                    value={company.id}

                                >

                                    {company.companyName}

                                </option>


                            ))

                        }



                    </select>


                </Box>








                <TextField

                    label="Branch Code"

                    name="branchCode"

                    value={form.branchCode}

                    onChange={handleChange}

                    required

                />






                <TextField

                    label="Branch Name"

                    name="branchName"

                    value={form.branchName}

                    onChange={handleChange}

                    required

                />







                <TextField

                    label="Address"

                    name="address"

                    value={form.address}

                    onChange={handleChange}

                />







                <TextField

                    label="City"

                    name="city"

                    value={form.city}

                    onChange={handleChange}

                />







                <TextField

                    label="State"

                    name="state"

                    value={form.state}

                    onChange={handleChange}

                />







                <TextField

                    label="Country"

                    name="country"

                    value={form.country}

                    onChange={handleChange}

                />







                <TextField

                    label="Phone"

                    name="phone"

                    value={form.phone}

                    onChange={handleChange}

                />







                <TextField

                    label="Email"

                    name="email"

                    value={form.email}

                    onChange={handleChange}

                />







                <Button

                    variant="contained"

                    type="submit"

                >

                    {

                        editData

                        ?

                        "Update Branch"

                        :

                        "Save Branch"

                    }


                </Button>



            </Box>



        </Paper>


    );

}