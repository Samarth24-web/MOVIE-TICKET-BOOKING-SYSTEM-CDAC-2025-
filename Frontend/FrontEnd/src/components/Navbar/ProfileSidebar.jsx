import { useNavigate } from "react-router-dom";

const ProfileSidebar = ({ onClose }) => {
  const navigate = useNavigate();

  const logout = () => {
    localStorage.clear();
    navigate("/login");
  };

  return (
    <div
      style={{
        position: "fixed",
        top: 0,
        right: 0,
        height: "100vh",
        width: "300px",
        background: "#fff",
        boxShadow: "-2px 0 10px rgba(0,0,0,0.2)",
        zIndex: 1000,
        padding: "20px",
      }}
    >
      <button onClick={onClose}>✖</button>

      <div
        style={{ marginTop: "20px", cursor: "pointer" }}
        onClick={() => navigate("/profile")}
      >
        View Profile
      </div>

      <div
        style={{ marginTop: "20px", cursor: "pointer" }}
        onClick={() => navigate("/my-bookings")}
      >
        My Bookings
      </div>

      <div
        style={{ marginTop: "20px", cursor: "pointer", color: "red" }}
        onClick={logout}
      >
        Logout
      </div>
    </div>
  );
};

export default ProfileSidebar;
