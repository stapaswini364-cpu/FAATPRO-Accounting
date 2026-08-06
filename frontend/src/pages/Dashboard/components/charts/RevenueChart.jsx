import { useEffect, useState } from "react";

import {
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    ResponsiveContainer
} from "recharts";


import { getRevenueChart } from "../../../../api/dashboardApi";



const RevenueChart = () => {


    const [data,setData] = useState([]);



    useEffect(()=>{

        loadRevenue();

    },[]);





    const loadRevenue = async()=>{

        try{

            const response =
                await getRevenueChart();


            console.log(
                "Revenue Chart API:",
                response
            );


            setData(

                Array.isArray(response)
                ? response.map(item=>({

                    month:item.month,

                    revenue:item.amount

                }))
                : []

            );


        }
        catch(error){

            console.error(
                "Revenue Chart Error",
                error
            );

        }

    };






    return(

        <ResponsiveContainer
            width="100%"
            height={300}
        >

            <LineChart data={data}>


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



                <Line

                    type="monotone"

                    dataKey="revenue"

                    strokeWidth={3}

                />


            </LineChart>


        </ResponsiveContainer>

    );

};


export default RevenueChart;