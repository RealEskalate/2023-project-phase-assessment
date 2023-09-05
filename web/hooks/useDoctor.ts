import {
  useGetDoctorsQuery,
} from "../lib/redux/features/doctor";

export default function useDoctor() {
  const { data: doctors, isLoading, error } = useGetDoctorsQuery();
  return {
    getBlogs: () => ({
      doctors,
      isLoading,
      error,
    }),
  };
}
