const baseUrl = 'http://moodestabil.azurewebsites.net/api/subjects';

Vue.createApp({
    data() {
        return {
            subjects:[],
            IdToGetBy: -1,
            updateData: { id: 0, subjectName: "", subjectMeetTime: null },
            addData: { subjectName: "", subjectMeetTime: null },
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
            const url = baseUrl + "/" + id
            this.get(url);
        },
        async addSubject() {
            try {
                response = await axios.post(baseUrl, this.addData)
                this.addMessage = "response " + response.status + " " + response.statusText
                this.get()
                console.log(response.statusText);
            } catch (e) {
                alert(e.message)
            }
        },
        async updateSubject() {
            const url = baseUrl + "/" + this.subjectInfo.subject.id
            try {
                response = await axios.put(url, this.subjectInfo)
                this.updateMessage = "response " + response.status + " " + response.statusText
                this.get()
            } catch (e) {
                alert(e.message)
            }
        },
       
        async get(url) {
            try {
                const response = await axios.get(url)
                this.subjects = await response.data
                
            } catch (e) {
                alert(e.message)
            }
        },
    }
}).mount("#app")