import { useState } from "react";

import AccountHeadList from "./AccountHeadList";
import AccountHeadForm from "./components/AccountHeadForm";


export default function AccountHead()
{

    const [refresh,setRefresh] = useState(false);



    const handleSuccess = ()=>{

        setRefresh(!refresh);

    };



    return (

        <>

            <AccountHeadForm

                onSuccess={handleSuccess}

            />



            <AccountHeadList

                key={refresh}

            />


        </>

    );

}