import { useEffect, useState } from "react";

import {
    BarChart,
    Bar,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    ResponsiveContainer
} from "recharts";


import { getExpenseChart } from "../../../../api/dashboardApi";



const ExpenseChart = () => {


    const [data,setData] = useState([]);



    useEffect(()=>{

        loadExpense();

    },[]);





    const loadExpense = async()=>{

        try{

            const response =
                await getExpenseChart();


            console.log(
                "Expense Chart API:",
                response
            );



            setData(

                Array.isArray(response)

                ?

                response.map(item=>({

                    month:item.month,

                    expense:item.amount

                }))

                :

                []

            );


        }
        catch(error){

            console.error(
                "Expense Chart Error",
                error
            );

        }

    };






    return(

        <ResponsiveContainer
            width="100%"
            height={250}
        >

            <BarChart data={data}>


                <CartesianGrid />


                <XAxis
                    dataKey="month"
                />


                <YAxis />


                <Tooltip
                    formatter={
                        (value)=>
                            `₹ ${value.toLocaleString()}`
                    }
                />



                <Bar

                    dataKey="expense"

                    barSize={35}

                />


            </BarChart>


        </ResponsiveContainer>

    );

};


export default ExpenseChart;