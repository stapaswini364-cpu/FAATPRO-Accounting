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

import BranchForm from "./components/BranchForm";



export default function BranchList()
{

    const [branches,setBranches] = useState([]);

    const [showForm,setShowForm] = useState(false);



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
                "Branch loading failed:",
                error.response?.data || error.message
            );

        }

    };



    useEffect(()=>{

        loadBranches();

    },[]);



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
                onClick={()=>setShowForm(!showForm)}
            >
                Add Branch
            </Button>



            {
                showForm &&

                <BranchForm
                    onSuccess={()=>{

                        setShowForm(false);

                        loadBranches();

                    }}
                />

            }




            <TableContainer component={Paper}>

                <Table>


                    <TableHead>

                        <TableRow>

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
                                Phone
                            </TableCell>

                        </TableRow>

                    </TableHead>



                    <TableBody>


                    {
                        branches.length > 0 ?

                        branches.map((item)=>(

                            <TableRow key={item.id}>


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
                                    {item.phone}
                                </TableCell>


                            </TableRow>


                        ))

                        :

                        <TableRow>

                            <TableCell
                                colSpan={4}
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