import api from "./index";

export const getAnnouncementList = async ({
  pageNumber = 1,
  pageSize = 10,
}) => {
  const response = await api.get(
    `api/announcement?pageNumber=${pageNumber}&pageSize=${pageSize}`
  );
  const data = response.data;
  return data;
};

export const getAnnouncementDetail = async (slug) => {
  const response = await api.get(`api/Announcement/${slug}`);
  const data = response.data;
  return data;
};
