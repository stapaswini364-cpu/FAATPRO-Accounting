import { useState } from "react";

import FinancialYearList from "./FinancialYearList";
import FinancialYearForm from "./components/FinancialYearForm";


export default function FinancialYear()
{

    const [refresh,setRefresh] = useState(false);


    const handleSuccess = ()=>{

        setRefresh(!refresh);

    };


    return (

        <>

            <FinancialYearForm
                onSuccess={handleSuccess}
            />


            <FinancialYearList
                key={refresh}
            />


        </>

    );

}