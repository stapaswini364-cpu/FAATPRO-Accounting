import { useState } from "react";


const ResetPassword = () => {


const [password,setPassword] = useState("");

const [confirmPassword,setConfirmPassword] = useState("");




const handleSubmit = (e)=>{

e.preventDefault();


console.log({

password,

confirmPassword

});


};




return (

<div className="min-h-screen flex items-center justify-center bg-gray-100">


<div className="bg-white p-8 rounded-xl shadow-md w-full max-w-md">


<h1 className="text-3xl font-bold text-center mb-6">

Reset Password

</h1>



<form onSubmit={handleSubmit}>


<input

type="password"

placeholder="New Password"

value={password}

onChange={(e)=>setPassword(e.target.value)}

className="w-full border rounded-lg px-4 py-2 mb-4"

required

/>



<input

type="password"

placeholder="Confirm Password"

value={confirmPassword}

onChange={(e)=>setConfirmPassword(e.target.value)}

className="w-full border rounded-lg px-4 py-2 mb-5"

required

/>



<button

className="w-full bg-blue-600 text-white py-2 rounded-lg"

>

Update Password

</button>



</form>



</div>


</div>

);


};


export default ResetPassword;