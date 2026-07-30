import { useState } from "react";
import { useNavigate } from "react-router-dom";

import {
  Box,
  Button,
  Card,
  CardContent,
  Checkbox,
  FormControlLabel,
  TextField,
  Typography
} from "@mui/material";

import { login } from "../api/authApi";

const Login = () => {
  const navigate = useNavigate();

  const [email, setEmail] = useState("admin@faatpro.com");
  const [password, setPassword] = useState("Admin@123");
  const [rememberMe, setRememberMe] = useState(true);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);

  const handleLogin = async (e) => {
    e.preventDefault();

    setLoading(true);
    setError("");

    try {
      const response = await login({
        email: email.trim(),
        password,
        rememberMe
      });

      console.log("========== LOGIN SUCCESS ==========");
      console.log("FULL RESPONSE:", response);
      console.log("RESPONSE DATA:", response.data);
      console.log("===================================");

      const loginData = response.data.data;

      if (!loginData || !loginData.accessToken) {
        throw new Error("Access token not received.");
      }

      localStorage.setItem("token", loginData.accessToken);
      localStorage.setItem("refreshToken", loginData.refreshToken);
      localStorage.setItem("user", JSON.stringify(loginData.user));

      navigate("/", { replace: true });
    } catch (err) {
      console.log("========== LOGIN ERROR ==========");
      console.log("Message :", err.message);
      console.log("Status  :", err.response?.status);
      console.log("Response:", err.response);
      console.log("Data    :", err.response?.data);
      console.log("=================================");

      setError(
        err.response?.data?.message ||
        err.message ||
        "Login failed."
      );
    } finally {
      setLoading(false);
    }
  };

  return (
    <Box
      sx={{
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center"
      }}
    >
      <Card sx={{ width: 400, p: 2 }}>
        <CardContent>
          <Typography
            variant="h5"
            align="center"
            sx={{ mb: 3 }}
          >
            FAATPRO Login
          </Typography>

          {error && (
            <Typography color="error" sx={{ mb: 2 }}>
              {error}
            </Typography>
          )}

          <form onSubmit={handleLogin}>
            <TextField
              fullWidth
              label="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              margin="normal"
            />

            <TextField
              fullWidth
              label="Password"
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              margin="normal"
            />

            <FormControlLabel
              control={
                <Checkbox
                  checked={rememberMe}
                  onChange={(e) => setRememberMe(e.target.checked)}
                />
              }
              label="Remember Me"
            />

            <Button
              type="submit"
              fullWidth
              variant="contained"
              disabled={loading}
              sx={{ mt: 2 }}
            >
              {loading ? "Logging in..." : "Login"}
            </Button>
          </form>
        </CardContent>
      </Card>
    </Box>
  );
};

export default Login;