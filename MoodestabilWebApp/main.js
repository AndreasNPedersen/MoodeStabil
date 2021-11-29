/// <reference path="assets/chartJS/ourCharts.js"/>
const baseUrl = 'https://moodestabil.azurewebsites.net/api';

Vue.createApp({
    data() {
        return {
            dateRangeStart: new Date(2021, 11, 29, 9, 10, 00, 0),
            dateRangeEnd: new Date(2021, 12, 3, 10, 10, 00, 0),
            piDataList: [],
            piDataInfo: {
                id: 0,
                dateFromSubject: null,
                date: null,
                subjectId: 0,
                subject: {
                    id: 0,
                    subjectName: "",
                    subjectMeetTime: null
                }
            },
            subjects:[],
            subjectInfo: {
                id: 0,
                subjectName: "string",
                subjectMeetTime: "",
                piData: [
                    {
                        id: 0,
                        dateFromSubject: "",
                        date: "",
                        subjectId: 0,
                        subject: {
                        id: 0,
                        subjectName: "string",
                        subjectMeetTime: ""
                        }
                    }
                ]
            }
        }
    },
    created() {
        this.getLastFiveDays();
    },
    methods: {
        // Subject Methods
        async getAllSubjects() {
            this.get(baseUrl);
        },
        async getSubjectById(id) {
            const url = baseUrl + "/Subjects/" + id
            this.get(url);
        },
        async addSubject() {
            try {
                response = await axios.post(baseUrl, this.subjectInfo)
                this.addMessage = "response " + response.status + " " + response.statusText
                this.get()
                console.log(response.statusText);
            } catch (e) {
                alert(e.message)
            }
        },
        async updateSubject() {
            const url = baseUrl + "/SubjectsController/" + this.subjectInfo.subject.id
            try {
                response = await axios.put(url, this.subjectInfo)
                this.updateMessage = "response " + response.status + " " + response.statusText
                this.get()
            } catch (e) {
                alert(e.message)
            }
        },
        // Pi Data
        async getAllPiData() {
            this.get(baseUrl + "/PiData");
        },
        async getAllPiDataFiveDays() {
            const url = baseUrl + "/PiDataController/days/5"
            this.get(url);
        },
        async getPiDataById(id) {
            const url = baseUrl + "/PiDataController/" + id
            this.get(url);
        },
        async addPiData() {
            try {
                response = await axios.post(baseUrl, this.piDataInfo)
                this.addMessage = "response " + response.status + " " + response.statusText
                this.get()
                console.log(response.statusText);
            } catch (e) {
                alert(e.message)
            }
        },
        async updatePiData() {
            const url = baseUrl + "/PiDataController/" + this.piDataInfo.piData.id
            try {
                response = await axios.put(url, this.piDataInfo)
                this.updateMessage = "response " + response.status + " " + response.statusText
                this.get()
            } catch (e) {
                alert(e.message)
            }
        },
        async deletePiData(id) {
            const deleteUrl = baseUrl + "/PiDataController/" + id
            try {
                response = await axios.delete(deleteUrl)
                this.deleteMessage = response.status + " " + response.statusText
                this.get()
            } catch (e) {
                alert(e.message)
            }
        },
        // Actual Get Method
        async get(url) {
            try {
                const response = await axios.get(url)
                this.piDataList = await response.data
                updateCharts(this.piDataList);
            } catch (e) {
                alert(e.message)
            }
        },
        async getLastFiveDays() {
            try {
                const response = await axios.get(baseUrl + "/PiData/GetLastFiveDays")
                this.piDataList = await response.data
                updateCharts(this.piDataList);
            } catch (e) {
                alert(e.message)
            }
        },
        // Filter Methods
        async getDateRange() {
            var currentDate = Date.get();
            this.dateRangeEnd = currentDate;
            this.dateRangeStart = new Date(currentDate.getYear(), currentDate.getMonth(), currentDate.getDate() - 5, 0, 0, 00, 0);
        }
    }
}).mount("#app")