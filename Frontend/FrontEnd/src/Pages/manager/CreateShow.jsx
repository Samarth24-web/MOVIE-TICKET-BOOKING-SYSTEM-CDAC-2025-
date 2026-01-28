import { useEffect, useState } from "react";
import toast from "react-hot-toast";
import axiosInstance from "../../app/axiosInstance";
import { createShowApi } from "../../features/show/showApi";

const CreateShow = () => {
  const managerId = localStorage.getItem("userId");
  const theatreId = localStorage.getItem("theatreId");

  const [movies, setMovies] = useState([]);
  const [screens, setScreens] = useState([]);
  const [languages, setLanguages] = useState([]);

  const [form, setForm] = useState({
    movieId: "",
    screenId: "",
    languageId: "",
    showDate: "",
    startTime: "",
    endTime: "",
  });

  const [errors, setErrors] = useState({});

  useEffect(() => {
    loadData();
  }, []);

  const loadData = async () => {
    try {
      const m = await axiosInstance.get("/movie");
      const s = await axiosInstance.get(
        `/screens/by-theatre/${theatreId}`
      );
      const l = await axiosInstance.get("/languages");

      setMovies(m.data);
      setScreens(s.data);
      setLanguages(l.data);
    } catch {
      toast.error("Failed to load data");
    }
  };

  const validate = () => {
    const e = {};
    if (!form.movieId) e.movieId = "Select movie";
    if (!form.screenId) e.screenId = "Select screen";
    if (!form.languageId) e.languageId = "Select language";
    if (!form.showDate) e.showDate = "Select date";
    if (!form.startTime) e.startTime = "Start time required";
    if (!form.endTime) e.endTime = "End time required";

    if (
      form.startTime &&
      form.endTime &&
      form.endTime <= form.startTime
    ) {
      e.endTime = "End time must be after start time";
    }

    setErrors(e);
    return Object.keys(e).length === 0;
  };

  const handleSubmit = async () => {
    if (!validate()) return;

    try {
      await createShowApi({
        ...form,
        createdByManagerId: managerId,
      });

      toast.success("Show registered successfully");
      setForm({
        movieId: "",
        screenId: "",
        languageId: "",
        showDate: "",
        startTime: "",
        endTime: "",
      });
    } catch {
      toast.error("Failed to create show");
    }
  };

  return (
    <div style={{ maxWidth: "600px" }}>
      <h2>Register Show</h2>

      <select
        value={form.movieId}
        onChange={(e) =>
          setForm({ ...form, movieId: e.target.value })
        }
      >
        <option value="">Select Movie</option>
        {movies.map((m) => (
          <option key={m.movieId} value={m.movieId}>
            {m.title}
          </option>
        ))}
      </select>
      <p className="error">{errors.movieId}</p>

      <select
        value={form.screenId}
        onChange={(e) =>
          setForm({ ...form, screenId: e.target.value })
        }
      >
        <option value="">Select Screen</option>
        {screens.map((s) => (
          <option key={s.screenId} value={s.screenId}>
            {s.screenName}
          </option>
        ))}
      </select>
      <p className="error">{errors.screenId}</p>

      <select
        value={form.languageId}
        onChange={(e) =>
          setForm({ ...form, languageId: e.target.value })
        }
      >
        <option value="">Select Language</option>
        {languages.map((l) => (
          <option key={l.languageId} value={l.languageId}>
            {l.languageName}
          </option>
        ))}
      </select>
      <p className="error">{errors.languageId}</p>

      <input
        type="date"
        value={form.showDate}
        onChange={(e) =>
          setForm({ ...form, showDate: e.target.value })
        }
      />
      <p className="error">{errors.showDate}</p>

      <input
        type="time"
        value={form.startTime}
        onChange={(e) =>
          setForm({ ...form, startTime: e.target.value })
        }
      />
      <p className="error">{errors.startTime}</p>

      <input
        type="time"
        value={form.endTime}
        onChange={(e) =>
          setForm({ ...form, endTime: e.target.value })
        }
      />
      <p className="error">{errors.endTime}</p>

      <button onClick={handleSubmit}>Create Show</button>
    </div>
  );
};

export default CreateShow;
