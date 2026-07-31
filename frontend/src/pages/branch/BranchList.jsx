import { useEffect, useState } from "react";

import {
    Box,
    Button,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography
} from "@mui/material";


import branchApi from "../../api/branchApi";
import companyApi from "../../api/companyApi";

import BranchForm from "./components/BranchForm";



export default function BranchList()
{


    const [branches,setBranches] = useState([]);

    const [companies,setCompanies] = useState([]);

    const [showForm,setShowForm] = useState(false);

    const [editData,setEditData] = useState(null);





    const loadBranches = async()=>{

        try{

            const response = await branchApi.getAll();

            console.log(
                "BRANCH RESPONSE:",
                response.data
            );


            setBranches(
                response.data?.data ?? response.data ?? []
            );


        }
        catch(error){

            console.error(
                "Branch loading failed",
                error
            );

        }

    };





    const loadCompanies = async()=>{

        try{

            const data = await companyApi.getAll();

            setCompanies(data);

        }
        catch(error){

            console.error(
                "Company loading failed",
                error
            );

        }

    };






    useEffect(()=>{

        loadBranches();

        loadCompanies();

    },[]);







    const getCompanyName=(id)=>{


        const company = companies.find(

            x=>x.id===id

        );


        return company
        ?
        company.companyName
        :
        "-";

    };






    const handleDelete=async(id)=>{


        if(!window.confirm("Delete branch?"))
            return;


        try{

            await branchApi.remove(id);

            loadBranches();

        }
        catch(error){

            console.error(
                "Delete failed",
                error
            );

        }

    };








    return (

        <Box>


            <Typography
                variant="h5"
                mb={3}
            >
                Branch Master
            </Typography>





            <Button

                variant="contained"

                sx={{mb:2}}

                onClick={()=>{

                    setEditData(null);

                    setShowForm(!showForm);

                }}

            >

                Add Branch

            </Button>





            {
                showForm &&

                <BranchForm

                    editData={editData}

                    onSuccess={()=>{

                        setShowForm(false);

                        setEditData(null);

                        loadBranches();

                    }}

                />

            }







            <TableContainer component={Paper}>


                <Table>



                    <TableHead>

                        <TableRow>


                            <TableCell>
                                Company
                            </TableCell>


                            <TableCell>
                                Code
                            </TableCell>


                            <TableCell>
                                Name
                            </TableCell>


                            <TableCell>
                                City
                            </TableCell>


                            <TableCell>
                                State
                            </TableCell>


                            <TableCell>
                                Phone
                            </TableCell>


                            <TableCell>
                                Status
                            </TableCell>


                            <TableCell>
                                Action
                            </TableCell>


                        </TableRow>


                    </TableHead>





                    <TableBody>


                    {
                        branches.length > 0

                        ?

                        branches.map((item)=>(


                            <TableRow key={item.id}>


                                <TableCell>

                                    {
                                        getCompanyName(
                                            item.companyId
                                        )
                                    }

                                </TableCell>



                                <TableCell>
                                    {item.branchCode}
                                </TableCell>



                                <TableCell>
                                    {item.branchName}
                                </TableCell>



                                <TableCell>
                                    {item.city}
                                </TableCell>



                                <TableCell>
                                    {item.state}
                                </TableCell>



                                <TableCell>
                                    {item.phone}
                                </TableCell>



                                <TableCell>

                                    {
                                        item.isActive
                                        ?
                                        "Active"
                                        :
                                        "Inactive"
                                    }

                                </TableCell>




                                <TableCell>


                                    <Button

                                        size="small"

                                        onClick={()=>{

                                            setEditData(item);

                                            setShowForm(true);

                                        }}

                                    >

                                        Edit

                                    </Button>





                                    <Button

                                        size="small"

                                        color="error"

                                        onClick={()=>handleDelete(item.id)}

                                    >

                                        Delete

                                    </Button>



                                </TableCell>



                            </TableRow>


                        ))

                        :


                        <TableRow>

                            <TableCell
                                colSpan={8}
                                align="center"
                            >

                                No Branch Found

                            </TableCell>


                        </TableRow>


                    }



                    </TableBody>


                </Table>


            </TableContainer>



        </Box>

    );


}