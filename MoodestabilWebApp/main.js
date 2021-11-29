const baseUrl = 'http://moodestabil.azurewebsites.net/api';

Vue.createApp({
    data() {
        return {
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
    methods: {
        // Subject Methods
        async getAllSubjects() {
            this.get(baseUrl);
        },
        async getSubjectById(id) {
            const url = baseUrl + "/SubjectsController/" + id
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
            this.get(baseUrl + "Pidata");
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
                console.log(this.Records)
            } catch (e) {
                alert(e.message)
            }
        }
    }
}).mount("#app")